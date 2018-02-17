using cams.model.Items;
using cams.MongoDBConnector.Core;
using cams.MongoDBConnector.Sessions;

namespace cams.MongoDBConnector.Items
{
    public class ItemRepository : RepositoryBase, IItemRepository
    {
        public ItemRepository(IMongoDBSessionFactory factory) :
            base(factory)
        {

        }
    }
}
