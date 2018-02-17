using cams.model.Collections;
using cams.MongoDBConnector.Core;
using cams.MongoDBConnector.Sessions;

namespace cams.MongoDBConnector.Collections
{
    public class CollectionRepository : RepositoryBase, ICollectionRepository
    {
        public CollectionRepository(IMongoDBSessionFactory factory) :
            base(factory)
        {

        }
    }
}
