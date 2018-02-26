using cams.model.QueryParameters.Pages;

namespace cams.MongoDBConnector.Sessions
{
    internal static class MongoDBPagingParametersExtensions
    {
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