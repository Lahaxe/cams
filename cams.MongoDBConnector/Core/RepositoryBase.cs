using cams.model.Core;
using cams.MongoDBConnector.Sessions;
using System;

namespace cams.MongoDBConnector.Core
{
    /// <summary>
    /// Defines base class for repository.
    /// </summary>
    public class RepositoryBase : IRepository
    {
        /// <summary>
        /// The MongoDB session factory.
        /// </summary>
        private readonly IMongoDBSessionFactory _factory;

        /// <summary>
        /// The MongoDB session.
        /// </summary>
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

        /// <summary>
        /// Initialize a new instance of <see cref="RepositoryBase"/>.
        /// </summary>
        /// <param name="factory">The MongoDB session factory.</param>
        protected RepositoryBase(IMongoDBSessionFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="RepositoryBase"/>.
        /// </summary>
        /// <param name="session">The MongoDB session.</param>
        protected RepositoryBase(MongoDBSession session)
        {
            _session = session;
        }

        /// <summary>
        /// Disposes the repository.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}