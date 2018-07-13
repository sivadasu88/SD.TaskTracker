namespace SD.TaskTracker.Api
{
    public class IdentityServerClientConfig
    {
        /// <summary>
        /// Gets or sets client key (aka client id)
        /// </summary>
        public string ClientKey { get; set; }

        /// <summary>
        /// Gets or sets client's secret
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or set root url of OAuth identity server
        /// </summary>
        public string IdentityServerUrl { get; set; }

        /// <summary>
        /// Gets or sets space separated values
        /// </summary>
        public string ResourceScope { get; set; }
    }
}
