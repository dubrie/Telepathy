﻿//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//      The main entry point for the application.
// </summary>
//------------------------------------------------------------------------------
namespace Microsoft.Hpc.Scheduler.Session.Internal.LauncherHostService
{
    using System;
    using System.Diagnostics;
    using System.ServiceProcess;
    using System.Threading;

    using CommandLine;

    using Microsoft.Hpc.RuntimeTrace;
    using Microsoft.Hpc.Scheduler.Session.Internal.SessionLauncher;
    using Microsoft.Hpc.Scheduler.Session.Internal.SessionLauncher.Impls;
    using Microsoft.Hpc.Scheduler.Session.Internal.SessionLauncher.Impls.AzureBatch;
    using Microsoft.Hpc.Scheduler.Session.Internal.SessionLauncher.Impls.Local;
    using Microsoft.Hpc.Scheduler.Session.LauncherHostService;

    using Serilog;

    /// <summary>
    /// Main entry point
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [LoaderOptimization(LoaderOptimization.MultiDomain)]
        private static void Main(string[] args)
        {
            var log = new LoggerConfiguration().ReadFrom.AppSettings().Enrich.WithMachineName().CreateLogger();
            Serilog.Debugging.SelfLog.Enable(Console.Out);

            Log.Logger = log;

            if (!ParseAndSetGlobalConfiguration(args))
            {
                // Parsing error
                return;
            }

            if (SessionLauncherRuntimeConfiguration.SchedulerType == SchedulerType.HpcPack)
            {
                HpcContext.AsNtServiceContext();
                HpcContext.GetOrAdd(CancellationToken.None);
            }
            else
            {
                // TODO: these lines will be different after a domain specific context is added to the project
                HpcContext.AsNtServiceContext();
                HpcContext.GetOrAdd(CancellationToken.None);
            }

            LauncherHostService host = null;
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            if (SessionLauncherRuntimeConfiguration.AsConsole)
            {
                try
                {
                    host = new LauncherHostService();
                    host.OpenService().Wait();
                    Console.WriteLine("Press any key to exit...");
                    Thread.Sleep(-1);
                }

                finally
                {
                    if (host != null)
                    {
                        try
                        {
                            host.StopService();
                        }

                        catch (Exception e)
                        {
                            Trace.TraceError("Exception stopping service - " + e);
                        }
                    }
                }
            }
            else
            {
                ServiceBase[] servicesToRun;
                servicesToRun = new ServiceBase[] { new LauncherHostService() };
                ServiceBase.Run(servicesToRun);
            }

            Log.CloseAndFlush();
        }

        /// <summary>
        /// event to trace the unhandled exception.
        /// </summary>
        /// <param name="sender">the sender.</param>
        /// <param name="e">the exception arguments.</param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            TraceHelper.TraceEvent(TraceEventType.Critical, "[SessionLauncher] Unhandled {2} exception found in {0}: \n{1}", sender, e.ExceptionObject, e.IsTerminating ? "fatal" : String.Empty);
            Log.CloseAndFlush();
        }

        private static bool ParseAndSetGlobalConfiguration(string[] args)
        {
            void SetGlobalConfiguration(SessionLauncherStartOption option)
            {
                if (option.AsConsole)
                {
                    SessionLauncherRuntimeConfiguration.AsConsole = true;
                }

                if (!string.IsNullOrEmpty(option.AzureBatchServiceUrl))
                {
                    SessionLauncherRuntimeConfiguration.SchedulerType = SchedulerType.AzureBatch;
                    AzureBatchConfiguration.BatchServiceUrl = option.AzureBatchServiceUrl;
                    AzureBatchConfiguration.BatchAccountName = option.AzureBatchAccountName;
                    AzureBatchConfiguration.BatchAccountKey = option.AzureBatchAccountKey;
                    AzureBatchConfiguration.SoaBrokerStorageConnectionString = option.AzureBatchBrokerStorageConnectionString;
                }
                else if (!string.IsNullOrEmpty(option.HpcPackSchedulerAddress))
                {
                    SessionLauncherRuntimeConfiguration.SchedulerType = SchedulerType.HpcPack;
                }
                else if (!string.IsNullOrEmpty(option.BrokerLauncherExePath))
                {
                    SessionLauncherRuntimeConfiguration.SchedulerType = SchedulerType.Local;
                    LocalSessionConfiguration.BrokerLauncherExePath = option.BrokerLauncherExePath;
                    LocalSessionConfiguration.ServiceHostExePath = option.ServiceHostExePath;
                    LocalSessionConfiguration.ServiceRegistrationPath = option.ServiceRegistrationPath;
                    LocalSessionConfiguration.BrokerStorageConnectionString = option.LocalBrokerStorageConnectionString;
                }

                if (!string.IsNullOrEmpty(option.AzureBatchPoolName))
                {
                    AzureBatchConfiguration.BatchPoolName = option.AzureBatchPoolName;
                }

                if (!string.IsNullOrEmpty(option.SessionLauncherStorageConnectionString))
                {
                    SessionLauncherRuntimeConfiguration.SessionLauncherStorageConnectionString = option.SessionLauncherStorageConnectionString;
                }
            }

            var result = new Parser(s =>
                {
                    s.CaseSensitive = false;
                    s.HelpWriter = Console.Error;
                }).ParseArguments<SessionLauncherStartOption>(args).WithParsed(SetGlobalConfiguration);
            return result.Tag == ParserResultType.Parsed;
        }
    }
}
