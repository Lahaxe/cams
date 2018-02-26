using cams.model.QueryParameters.Pages;

namespace cams.MongoDBConnector.QueryParameters
{
    /// <summary>
    /// Defines converters for <see cref="PagingParameters"/>.
    /// </summary>
    internal static class MongoDBPagingParametersExtensions
    {
        /// <summary>
        /// Converts paging parameters to MongoDB paging parameters.
        /// </summary>
        /// <param name="paging">The paging parameters to convert.</param>
        /// <returns>The converted MongoDB paging parameters.</returns>
        public static MongoDBPagingParameters ToMDBPagingParameters(this PagingParameters paging)
        {
            if (paging == null)
            {
                return null;
            }

            return new MongoDBPagingParameters { Limit = paging.Size, Skip = (paging.Index - 1) * paging.Size };
        }
    }
}