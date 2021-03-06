﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

namespace Microsoft.Telepathy.ServiceBroker.Common
{
    using System;

    /// <summary>
    /// Define broker's states
    /// </summary>
    [Serializable]
    public enum BrokerState
    {
        /// <summary>
        /// The broker is not started
        /// </summary>
        NotStarted = 0,

        /// <summary>
        /// The broker is started
        /// </summary>
        Started,

        /// <summary>
        /// The broker is running
        /// </summary>
        Running,

        /// <summary>
        /// The broker is idle
        /// </summary>
        Idle,

        /// <summary>
        /// The broker is finishing
        /// </summary>
        Finishing,

        /// <summary>
        /// The broker is finished
        /// </summary>
        Finished,

        /// <summary>
        /// The broker is suspend
        /// </summary>
        Suspend,
    }
}
