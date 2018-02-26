using cams.model.Items;
using cams.MongoDBConnector.Core;
using cams.MongoDBConnector.Sessions;

namespace cams.MongoDBConnector.Items
{
    /// <summary>
    /// Defines the item repository.
    /// </summary>
    public class ItemRepository : RepositoryBase, IItemRepository
    {
        /// <summary>
        /// Initiliaze a new instance of <see cref="ItemRepository"/>.
        /// </summary>
        /// <param name="factory">The MongoDB session factory.</param>
        public ItemRepository(IMongoDBSessionFactory factory) :
            base(factory)
        {
        }
    }
}