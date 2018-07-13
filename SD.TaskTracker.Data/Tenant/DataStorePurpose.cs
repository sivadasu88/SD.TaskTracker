using System;
using System.Collections.Generic;
using System.Text;

namespace SD.TaskTracker.Data.Tenant
{
    public enum DataStorePurpose
    {
        /// <summary>
        /// Data store can ONLY be used for Read and Write operations
        /// </summary>
        ReadOnly,

        /// <summary>
        /// Data store can be used for BOTH Read AND Write operations
        /// </summary>
        ReadWrite
    }
}
