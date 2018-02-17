using cams.model.Core;
using cams.MongoDBConnector.Sessions;
using System;

namespace cams.MongoDBConnector.Core
{
    public class RepositoryBase : IRepository
    {
        private readonly IMongoDBSessionFactory _factory;

        private MongoDBSession _session;

        /// <summary>
        /// Gets the session.
        /// </summary>
        protected MongoDBSession Session
        {
            get
            {
                if (_session != null)
                {
                    return _session;
                }
                if (_factory != null)
                {
                    _session = (MongoDBSession)_factory.CreateSession();
                    return _session;
                }

                return null;
            }
        }

        protected RepositoryBase(IMongoDBSessionFactory factory)
        {
            _factory = factory;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
