using cams.model.Collections;
using cams.MongoDBConnector.Core;
using cams.MongoDBConnector.Sessions;

namespace cams.MongoDBConnector.Collections
{
    /// <summary>
    /// Defines the collection repository.
    /// </summary>
    public class CollectionRepository : RepositoryBase, ICollectionRepository
    {
        /// <summary>
        /// Initialize a new instance of <see cref="CollectionRepository"/>.
        /// </summary>
        /// <param name="factory">The MongoDB session factory.</param>
        public CollectionRepository(IMongoDBSessionFactory factory) :
            base(factory)
        {
        }
    }
}