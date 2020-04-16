﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

namespace Microsoft.Telepathy.ServiceBroker.UnitTest.Mock
{
    using System.Runtime.Serialization;
    using System.Security.Principal;

    using Microsoft.Telepathy.Session.Interface;

    /// <summary>
    /// Mock object for broker authorization
    /// </summary>
    internal class MockBrokerAuthorization : BrokerAuthorization
    {
        /// <summary>
        /// Stores whether the mock object allows access or not
        /// </summary>
        private bool allow;

        /// <summary>
        /// Gets or sets a value indicating whether the authorization allows the access or not
        /// </summary>
        public bool Allow
        {
            get
            {
                return this.allow;
            }

            set
            {
                this.allow = value;
            }
        }

        /// <summary>
        /// Check the access
        /// Set allow to true to let it return true, otherwise false
        /// </summary>
        /// <param name="context">security context</param>
        /// <returns>ture or false</returns>
        public override bool CheckAccess(System.ServiceModel.ServiceSecurityContext context)
        {
            return this.allow;
        }

        public MockBrokerAuthorization(string allowedUser) : base(allowedUser)
        {
        }

        public MockBrokerAuthorization(string sddl, int desiredAccess, int genericRead, int genericWrite, int genericExecute, int genericAll) : base(sddl, desiredAccess, genericRead, genericWrite, genericExecute, genericAll)
        {
        }

        protected MockBrokerAuthorization(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public MockBrokerAuthorization() : this(null)
        {
        }
    }
}
