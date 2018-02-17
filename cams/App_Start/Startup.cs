using cams.model.Users;
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
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Dependency injection container
            var container = new UnityContainer();
            container.RegisterInstance(app);

            container.RegisterType<IMongoDBSessionFactory, MongoDBSessionFactory>();

            container.RegisterType<IUserRepository, UserRepository>(new InjectionConstructor(typeof(IMongoDBSessionFactory)));

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                new Unity.WebApi.UnityDependencyResolver(container);

            ConfigureOAuth(app);
        }
    }
}
