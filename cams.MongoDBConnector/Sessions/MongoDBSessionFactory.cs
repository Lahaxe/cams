using cams.model.Core;

namespace cams.MongoDBConnector.Sessions
{
    public class MongoDBSessionFactory : IMongoDBSessionFactory
    {
        ISession ISessionFactory.CreateSession()
        {
            MongoDBSession session = new MongoDBSession();
            session.Connect();
            return session;
        }
    }
}
