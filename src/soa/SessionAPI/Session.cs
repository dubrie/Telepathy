//------------------------------------------------------------------------------
// <copyright file="Session.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//      The implementation of the Session Class
// </summary>
//------------------------------------------------------------------------------


namespace Microsoft.Hpc.Scheduler.Session
{
    using Microsoft.Hpc.Scheduler.Session.Internal;
    using System;
    using System.Diagnostics;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The jobs associated with this object will be automatically closed on disposing this object
    /// </summary>
    public class V3Session : SessionBase
    {
        /// <summary>
        /// Whether the jobs will be closed on disposing this session
        /// </summary>
        private bool autoCloseJob;

        /// <summary>
        /// Initializes a new instance of the Session class
        /// </summary>
        /// <param name="info">session info</param>
        /// <param name="headnode">headnode name</param>
        /// <param name="sharedSession">if this is a shared session</param>
        /// <param name="binding">indicating the binding</param>
        public V3Session(SessionInfoBase info, string headnode, bool autoClose, Binding binding)
            : base(info, headnode, binding)
        {
            this.autoCloseJob = !autoClose;

            SessionBase.TraceSource.TraceInformation("[Session:{0}] Interactive session created.", info.Id);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the job will be automatically closed on disposal of this session
        /// </summary>
        public bool AutoClose
        {
            get { return this.autoCloseJob; }
            set
            {
                // we don't protect here since this is simple type assignment.
                this.autoCloseJob = value;
            }
        }

        /// <summary>
        /// Gets the Net.Tcp endpoint reference for load balancer of this session
        /// </summary>
        public EndpointAddress NetTcpEndpointReference
        {
            get
            {
                if ((this.Info.TransportScheme & TransportScheme.NetTcp) == 0 || this.Info.UseInprocessBroker || !(this.Info is SessionInfo))
                {
                    return null;
                }
                else
                {
                    return GenerateEndpointAddress(((SessionInfo)this.Info).BrokerEpr, TransportScheme.NetTcp);
                }
            }
        }

        /// <summary>
        /// Gets the Http endpoint reference for load balancer of this session
        /// </summary>
        public EndpointAddress HttpEndpointReference
        {
            get
            {
                if ((this.Info.TransportScheme & (TransportScheme.Http | TransportScheme.NetHttp)) == 0 || this.Info.UseInprocessBroker || !(this.Info is SessionInfo))
                {
                    return null;
                }
                else
                {
                    return GenerateEndpointAddress(((SessionInfo)this.Info).BrokerEpr, TransportScheme.Http);
                }
            }
        }

        /// <summary>
        /// This method closes the session with the given ID
        /// </summary>
        /// <param name="headNode">Headnode name</param>
        /// <param name="sessionId">The ID of the session to be closed</param>
        /// <param name="isAadUser">If the session is belong to a AAD user</param>
        public static void CloseSession(string headNode, int sessionId, bool isAadUser)
        {
            CloseSession(headNode, sessionId, null, isAadUser);
        }

        /// <summary>
        /// This method closes the session with the given ID
        /// </summary>
        /// <param name="headNode">Headnode name</param>
        /// <param name="sessionId">The ID of the session to be closed</param>
        /// <param name="binding">indicting the binding</param>
        /// <param name="isAadUser">If the session is belong to a AAD user</param>
        public static void CloseSession(string headNode, int sessionId, Binding binding, bool isAadUser)
        {
            CloseSessionAsync(headNode, sessionId, binding, isAadUser, CancellationToken.None).GetAwaiter().GetResult();
        }

        /// <summary>
        /// This method closes the session async with the given ID
        /// </summary>
        /// <param name="headNode">Headnode name</param>
        /// <param name="sessionId">The ID of the session to be closed</param>
        /// <param name="binding">indicting the binding</param>
        /// <param name="isAadUser">If the session is belong to a AAD user</param>
        /// <param name="token">The cancellation token.</param>
        public static async Task CloseSessionAsync(string headNode, int sessionId, Binding binding, bool isAadUser, CancellationToken token)
        {
            Utility.ThrowIfEmpty(headNode, "headNode");

            SessionLauncherClient client = null;
            BrokerLauncherClient broker = null;

            string headNodeMachine = await HpcContext.GetOrAdd(headNode, token).ResolveSessionLauncherNodeAsync().ConfigureAwait(false);

            try
            {
                client = new SessionLauncherClient(headNodeMachine, binding, isAadUser);
                client.InnerChannel.OperationTimeout = GetTimeout(DateTime.MaxValue);
                //TODO: need to change the endpoint prefix for https
                SessionInfo info = null;
                if (binding is NetTcpBinding)
                {
                    info = Utility.BuildSessionInfoFromDataContract(await client.GetInfoV5Async(SessionLauncherClient.EndpointPrefix, sessionId).ConfigureAwait(false));
                }
#if !net40
                else if (binding is BasicHttpBinding || binding is NetHttpBinding || binding is NetHttpsBinding)
                {
                    info = Utility.BuildSessionInfoFromDataContract(await client.GetInfoV5Async(SessionLauncherClient.HttpsEndpointPrefix, sessionId).ConfigureAwait(false));
                }
#endif
                broker = new BrokerLauncherClient(info, binding, new Uri(info.BrokerLauncherEpr));
                broker.InnerChannel.OperationTimeout = GetTimeout(DateTime.MaxValue);
                broker.Close(sessionId);
            }
            catch (FaultException<SessionFault> e)
            {
                throw Utility.TranslateFaultException(e);
            }
            finally
            {
                if (client != null)
                {
                    Utility.SafeCloseCommunicateObject(client);
                }

                if (broker != null)
                {
                    Utility.SafeCloseCommunicateObject(broker);
                }
            }
        }

        /// <summary>
        /// Dispose the service job if autoclose is true
        /// </summary>
        /// <param name="disposing">if we called from destructor</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Nothing to do here
            }

            // Auto close the jobs if the autoCloseJob is set to true
            if (autoCloseJob)
            {
                try
                {
                    IBrokerLauncher broker = this.BrokerLauncherClientFactory.GetBrokerLauncherClient(-1);
                    broker.Close(this.Id);
                }
                catch (Exception e)
                {
                    // Swallow the exception
                    SessionBase.TraceSource.TraceInformation(e.ToString());
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Generate endpoint address by scheme from epr list
        /// </summary>
        /// <param name="eprList">indicating the epr list</param>
        /// <param name="scheme">indicating the scheme</param>
        /// <returns>endpoint address</returns>
        private static EndpointAddress GenerateEndpointAddress(string[] eprList, TransportScheme scheme)
        {
            int index = (int)Math.Log((int)scheme, 2);
            return new EndpointAddress(eprList[index]);
        }
    }
}
