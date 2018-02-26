using cams.model.Core;

namespace cams.MongoDBConnector.Sessions
{
    /// <summary>
    /// Defines a MongoDB session factory.
    /// </summary>
    public class MongoDBSessionFactory : IMongoDBSessionFactory
    {
        /// <summary>
        /// Creates a new MongoDB session.
        /// </summary>
        /// <returns></returns>
        ISession ISessionFactory.CreateSession()
        {
            MongoDBSession session = new MongoDBSession();
            session.Connect();
            return session;
        }
    }
}