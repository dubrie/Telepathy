﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

namespace Microsoft.Telepathy.ServiceBroker.BackEnd.DispatcherComponents
{
    using System;
    using System.ServiceModel.Channels;

    using Microsoft.Telepathy.ServiceBroker.BrokerQueue;

    /// <summary>
    /// Provides a data container for dispatching request
    /// </summary>
    internal sealed class DispatchData
    {
        /// <summary>
        /// Initializes a new instance of the DispatchData class
        /// </summary>
        /// <param name="sessionId">indicating the session id</param>
        /// <param name="clientIndex">indicating the client index</param>
        /// <param name="taskId">indicating the task id</param>
        public DispatchData(string sessionId, int clientIndex, string taskId)
        {
            this.SessionId = sessionId;
            this.ClientIndex = clientIndex;
            this.TaskId = taskId;
        }

        /// <summary>
        /// Gets or sets a value indicating whether try
        /// count should be decreased
        /// </summary>
        public bool? DecreaseTryCount { get; set; }

        /// <summary>
        /// Gets the session id
        /// </summary>
        public string SessionId { get; private set; }

        /// <summary>
        /// Gets the client index
        /// </summary>
        public int ClientIndex { get; private set; }

        /// <summary>
        /// Gets the task id
        /// </summary>
        public string TaskId { get; private set; }

        /// <summary>
        /// Gets or sets the broker queue item
        /// </summary>
        public BrokerQueueItem BrokerQueueItem { get; set; }

        /// <summary>
        /// Gets or sets the message id
        /// </summary>
        public Guid MessageId { get; set; }

        /// <summary>
        /// Gets or sets the exception
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets the reply message
        /// </summary>
        public Message ReplyMessage { get; set; }

        public IAsyncResult AsyncResult { get; set; }

        public DateTime DispatchTime { get; set; }

        public IService Client { get; set; }

        public string RequestAction { get; set; }

        public bool ServicePreempted { get; set; }

        public bool ExceptionHandled { get; set; }
    }
}
