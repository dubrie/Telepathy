﻿namespace Microsoft.Telepathy.ServiceBroker.UnitTest.Mock
{
    using System.Diagnostics;

    using Microsoft.Telepathy.ServiceBroker.BackEnd.nettcp;

    internal class MockAzureDispatcher : MockDispatcher
    {
        private ProxyClientPool proxyClientPool;

        public MockAzureDispatcher(ProxyClientPool proxyClientPool)
        {
            this.proxyClientPool = proxyClientPool;
        }

        public override bool CleanupClient(BackEnd.IService client)
        {
            AzureServiceClient serviceClient = client as AzureServiceClient;
            Debug.Assert(serviceClient != null);

            AzureServiceClient[] clients = null;
            lock (this.proxyClientPool)
            {
                clients = this.proxyClientPool.Clear(serviceClient);
            }

            if (clients != null)
            {
                // don't close client in above lock (this.proxyClientPool) scope to avoid deadlock
                foreach (AzureServiceClient asc in clients)
                {
                    asc.AsyncClose();
                }
            }

            return (clients != null);
        }
    }
}
