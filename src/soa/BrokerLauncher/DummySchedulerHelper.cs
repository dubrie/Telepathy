﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

namespace Microsoft.Telepathy.Internal.BrokerLauncher
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.Hpc.Scheduler.Session;
    using Microsoft.Hpc.Scheduler.Session.Internal;
    using Microsoft.Telepathy.Session.Interface;
    using Microsoft.Telepathy.Session.Internal;

    // No session service is in use
    internal class DummySchedulerHelper:ISchedulerHelper
    {
        internal static string DummyJobOnwerSID = "DUMMYJOBONWERSID";

        public bool Enable => false;

        public string HeadNode => string.Empty;

        public async Task<bool> IsJobPurged(string jobId)
        {
            return false;
        }

        public async Task UpdateBrokerInfo(BrokerInfo info)
        {
        }

        public async Task UpdateSuspended(string sessionId, bool suspended)
        {
        }

        public async Task<BrokerRecoverInfo[]> LoadBrokerRecoverInfo()
        {
            throw new System.InvalidOperationException();
        }

        public async Task<BrokerRecoverInfo> TryGetSessionStartInfoFromFininshedJobs(string sessionId)
        {
            throw new System.InvalidOperationException();
        }

        public async Task<string> GetJobTemplateACL(string jobTemplate)
        {
            throw new System.InvalidOperationException();
        }

        public async Task<string> GetJobOwnerSID(string jobId)
        {
            return DummyJobOnwerSID;
        }

        public async Task FailJob(string jobid, string reason)
        {
        }

        public async Task<bool> IsDiagTraceEnabled(string jobId)
        {
            return false;
        }

        public void Dispose()
        {
        }

        public async Task<Dictionary<string, string>> GetSOAConfigurations(List<string> keys)
        {
            // No store for now
            Dictionary<string, string> res = new Dictionary<string, string>();
            foreach (var key in keys)
            {
                string value = null;
                switch (key)
                {
                    case Constant.RegistryPathEnv:
                        value = BrokerLauncherSettings.Default.CCP_SERVICEREGISTRATION_PATH;
                        break;
                    case Constant.AutomaticShrinkEnabled:
                        value = "False";
                        break;
                    case Constant.NettcpOver443:
                        value = "True";
                        break;
                    case Constant.NetworkPrefixEnv:
                        value = string.Empty;
                        break;
                    case Constant.EnableFqdnEnv:
                        value = string.Empty;
                        break;
                    default:
                        throw new InvalidOperationException($"No default value for key {key}");
                        break;
                }

                res.Add(key, value);
            }

            return res;
        }

        public async Task<Dictionary<int, int>> GetNonTerminatedSession()
        {
            return new Dictionary<int, int>();
        }

        public async Task<ClusterInfoContract> GetClusterInfoAsync()
        {
            return new ClusterInfoContract()
                       {
                           ClusterName = BrokerLauncherSettings.Default.ClusterName,
                           ClusterId = BrokerLauncherSettings.Default.ClusterId,
                           NetworkTopology = "Public",
                           AzureStorageConnectionString = BrokerLauncherSettings.Default.AzureStorageConnectionString
                       };
        }
    }
}
