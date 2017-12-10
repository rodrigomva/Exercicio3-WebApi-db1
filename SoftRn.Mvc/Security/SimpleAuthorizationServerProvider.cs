using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

namespace SoftRn.Mvc.Security
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials([FromBody]OAuthGrantResourceOwnerCredentialsContext context)
        {
            //using (UsuarioRepository _repo = new UsuarioRepository())
            //{
           /* UsuarioRepository _repo = new UsuarioRepository();
            var user = _repo.GetAll().FirstOrDefault(u => u.Login.ToString() == context.UserName && u.Senha == context.Password && u.Status);

                if (user == null)
                {
                    context.SetError("invalid_grant", "Login ou senha incorretos");
                    return;
                }*/


            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);
        }
    }
}