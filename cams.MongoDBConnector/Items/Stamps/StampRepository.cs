using cams.model.Items.Stamps;
using cams.MongoDBConnector.Core;
using cams.MongoDBConnector.Sessions;

namespace cams.MongoDBConnector.Items.Stamps
{
    /// <summary>
    /// Defines the stamp repository.
    /// </summary>
    public class StampRepository : RepositoryBase, IStampRepository
    {
        /// <summary>
        /// Initialize a new instance of <see cref="StampRepository"/>.
        /// </summary>
        /// <param name="factory">The MongoDB session factory.</param>
        public StampRepository(IMongoDBSessionFactory factory) :
            base(factory)
        {
        }
    }
}