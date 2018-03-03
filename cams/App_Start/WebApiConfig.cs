using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace cams
{
    /// <summary>
    /// Defines the API configuration.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the configuration.
        /// </summary>
        /// <param name="config">The Web configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web

            // Configurer l'API Web pour utiliser uniquement l'authentification de jeton du porteur.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Formatter
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SerializerSettings
                .ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
            config.Formatters.JsonFormatter.SerializerSettings.Error += (sender, args) =>
            {
                // Expose any JSON serialization exception as HTTP error
                HttpContext.Current.AddError(args.ErrorContext.Error);
            };
        }
    }
}