using cams.model.Items.Stamps;
using cams.MongoDBConnector.Core;
using cams.MongoDBConnector.Sessions;

namespace cams.MongoDBConnector.Items.Stamps
{
    public class StampRepository : RepositoryBase, IStampRepository
    {
        public StampRepository(IMongoDBSessionFactory factory) :
            base(factory)
        {

        }
    }
}
