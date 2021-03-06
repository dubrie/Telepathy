﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

namespace Microsoft.Telepathy.ServiceBroker.BrokerQueue
{
    using System;

    /// <summary>
    /// the response event args definition.
    /// </summary>
    internal class ExceptionEventArgs : BrokerQueueEventArgs
    {
        #region private fields
        /// <summary>the exception.</summary>
        private Exception exceptionField;
        #endregion

        /// <summary>
        /// Initializes a new instance of the ExceptionEventArgs class for the broker queue.
        /// </summary>
        /// <param name="exception">the exception.</param>
        /// <param name="queue">the client id.</param>
        internal ExceptionEventArgs(Exception exception, BrokerQueue queue)
            : base(queue)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            this.exceptionField = exception;
        }

        /// <summary>
        /// Gets the exception
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "May need in the future")]
        public Exception Exception
        {
            get
            {
                return this.exceptionField;
            }
        }
    }
}
