﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

namespace Microsoft.Telepathy.ServiceBroker.BackEnd.DispatcherComponents
{
    using System.ServiceModel.Channels;

    /// <summary>
    /// This is a class for receiving response from on-premise service host.
    /// </summary>
    internal class OnPremiseResponseReceiver : ResponseReceiver
    {
        /// <summary>
        /// Initializes a new instance of the OnPremiseResponseReceiver class.
        /// </summary>
        public OnPremiseResponseReceiver(IDispatcher dispatcher)
            : base(dispatcher)
        {
        }

        /// <summary>
        /// Post process response message
        /// </summary>
        /// <param name="message">response message</param>
        protected override void PostProcessMessage(Message message)
        {
            return;
        }
    }
}
