using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security;
using System.Security.Claims;
using System.Threading.Tasks;

namespace cams.Providers
{
    public class CamsOAuthProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// Validates the client authentication.
        /// </summary>
        /// <param name="context">The authentication context.</param>
        /// <returns>The async task.</returns>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        /// <summary>
        /// Grant resources.
        /// </summary>
        /// <param name="context">The <see cref="OAuthGrantResourceOwnerCredentialsContext"/>.</param>
        /// <returns>The asynchronous task.</returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            await Task.Run(() =>
            {
                try
                {
                    /*var piivoContext = new PiivoAuthenticationContext
                    {
                        ClientId = context.ClientId,
                        UserName = context.UserName,
                        Password = context.Password
                    };

                    var customAuthorizationContext = (Container.IsRegistered<ICustomAuthorizationProcess>()) ? Container.Resolve<ICustomAuthorizationProcess>() : null;

                    if (customAuthorizationContext != null)
                    {
                        customAuthorizationContext.OnAuthorizing(ref piivoContext);
                    }

                    using (var session = new EveSession(piivoContext.UserName, piivoContext.Password))
                    {
                        var user = session.Api.User;
                        */
                        var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);

                        oAuthIdentity.AddClaim(new Claim(ClaimTypes.GivenName, context.UserName));
                        oAuthIdentity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                        //oAuthIdentity.AddClaim(new Claim(ClaimTypes.Sid, session.Api.Session.ToString()));

                        var props = CreateProperties(context.UserName,
                                                     "fr_FR");
                        var ticket = new AuthenticationTicket(oAuthIdentity, props);
                        context.Validated(ticket);
                    /*
                        if (customAuthorizationContext != null)
                        {
                            customAuthorizationContext.OnAuthorized(new PiivoAuthenticatedContext { Identity = oAuthIdentity });
                        }
                    }*/
                }
                catch (SecurityException)
                {
                    context.SetError("invalid_grant", "Nom d'utilisateur ou mot de passe incorrect.");
                }
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// The token end point.
        /// </summary>
        /// <param name="context">The token context.</param>
        /// <returns></returns>
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Create properties.
        /// </summary>
        /// <param name="userName">The username.</param>
        /// <param name="lang">The lang</param>
        /// <param name="authContext">The custom authentication context.</param>
        /// <returns>the <see cref="AuthenticationProperties"/>.</returns>
        public static AuthenticationProperties CreateProperties(string userName, string lang)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "username", userName },
                { "lang", lang }
            };

            return new AuthenticationProperties(data);
        }
    }
}