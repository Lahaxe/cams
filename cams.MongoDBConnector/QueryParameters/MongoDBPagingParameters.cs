namespace cams.MongoDBConnector.QueryParameters
{
    /// <summary>
    /// Defines a MongoDB paging parameters.
    /// </summary>
    public class MongoDBPagingParameters
    {
        /// <summary>
        /// Gets or sets skip option.
        /// </summary>
        public int? Skip { get; set; }

        /// <summary>
        /// Gets or sets limit option.
        /// </summary>
        public int? Limit { get; set; }
    }
}