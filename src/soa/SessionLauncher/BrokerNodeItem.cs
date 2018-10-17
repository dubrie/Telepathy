﻿//------------------------------------------------------------------------------
// <copyright file="BrokerNodeItem.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//      Provide a class for BrokerNode information.
// </summary>
//------------------------------------------------------------------------------

namespace Microsoft.Hpc.Scheduler.Session.Internal.SessionLauncher
{
    using Microsoft.Hpc.Scheduler.Properties;

    /// <summary>
    /// the broker node item.
    /// It is immutable.
    /// </summary>
    class BrokerNodeItem
    {
        /// <summary>
        /// the node name.
        /// </summary>
        private string nameField;

        /// <summary>
        /// the node domain name.
        /// </summary>
        private string domainNameField;

        /// <summary>
        /// the node state.
        /// </summary>
        private NodeState stateField;

        /// <summary>
        /// a valud indicating whether the node is reachable.
        /// </summary>
        private bool isReachableField;

        /// <summary>
        /// Initializes a new instance of the BrokerNodeItem class.
        /// </summary>
        /// <param name="name">the node name.</param>
        /// <param name="domainName">the node domain name.</param>
        /// <param name="state">the node state.</param>
        /// <param name="reachable">a value indicating whether the node is reachable.</param>
        public BrokerNodeItem(string name, string domainName, NodeState state, bool reachable)
        {
            ParamCheckUtility.ThrowIfNullOrEmpty(name, "name");

            // Make sure the name is saved in upper case so it can be easily looked up later
            this.nameField = name.ToUpper();

            if (!string.IsNullOrEmpty(domainName))
            {
                this.domainNameField = domainName.ToUpper();
            }

            this.stateField = state;
            this.isReachableField = reachable;
        }

        /// <summary>
        /// Gets the node name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.nameField;
            }
        }

        /// <summary>
        /// Gets the node domain name.
        /// </summary>
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
        }

        /// <summary>
        /// Gets or sets the node property.
        /// </summary>
        public NodeState State
        {
            get
            {
                return this.stateField;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the node is reachable.
        /// </summary>
        public bool Reachable
        {
            get
            {
                return this.isReachableField;
            }
        }
    }
}
