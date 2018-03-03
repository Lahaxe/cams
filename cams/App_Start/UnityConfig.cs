using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace cams
{
    /// <summary>
    /// Defines the unity configuration.
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// Registers all components.
        /// </summary>
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}