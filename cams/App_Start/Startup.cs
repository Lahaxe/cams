using cams.model.Collections;
using cams.model.Items;
using cams.model.Items.Stamps;
using cams.model.Users;
using cams.MongoDBConnector.Collections;
using cams.MongoDBConnector.Items;
using cams.MongoDBConnector.Items.Stamps;
using cams.MongoDBConnector.Sessions;
using cams.MongoDBConnector.Users;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Injection;

[assembly: OwinStartup(typeof(cams.Startup))]

namespace cams
{
    /// <summary>
    /// Defines the entry point.
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configuration(IAppBuilder app)
        {
            //Dependency injection container
            var container = new UnityContainer();
            container.RegisterInstance(app);

            // Register MongoDB Session Factory
            container.RegisterType<IMongoDBSessionFactory, MongoDBSessionFactory>();

            // Register User Repository
            container.RegisterType<IUserRepository, UserRepository>(new InjectionConstructor(typeof(IMongoDBSessionFactory)));
            // Register Collection Repository
            container.RegisterType<ICollectionRepository, CollectionRepository>(new InjectionConstructor(typeof(IMongoDBSessionFactory)));
            // Register Item Repository
            container.RegisterType<IItemRepository, ItemRepository>(new InjectionConstructor(typeof(IMongoDBSessionFactory)));

            // Register Stamp Repository
            container.RegisterType<IStampRepository, StampRepository>(new InjectionConstructor(typeof(IMongoDBSessionFactory)));

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                new Unity.WebApi.UnityDependencyResolver(container);

            ConfigureOAuth(app);
        }
    }
}