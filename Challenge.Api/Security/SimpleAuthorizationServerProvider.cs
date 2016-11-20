using Challenge.Domain.Commands.MarvelApi;
using Challenge.Domain.Contracts.Services.MarvelApi;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Api.Security
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        ICharacterAppService _characterAppService;

        public SimpleAuthorizationServerProvider(ICharacterAppService characterAppService)
        {
            _characterAppService = characterAppService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            AccessTokenCommand accessTokenCommand = new AccessTokenCommand(context.UserName, context.Password);

            string skip = "0";
            string take = "10";

            var result = _characterAppService.ValidAuthentication(accessTokenCommand, skip, take);

            if (result == false)
            {
                context.SetError("invalid_grant", "Chaves de usuários inválidas");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            GenericPrincipal principal = new GenericPrincipal(identity, new string[] { });
            Thread.CurrentPrincipal = principal;

            context.Validated(identity);
        }
    }
}