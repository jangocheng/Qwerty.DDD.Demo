using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Qwerty.DDD.Application.Interfaces.UserServiceInterfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer4.Authorization.Web
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserService _userService;

        public ResourceOwnerPasswordValidator(IUserService userService)
        {
            _userService = userService;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _userService.Login(context.UserName, context.Password);
            var extra = new Dictionary<string, object>();
            var claims = new List<Claim>
                            {
                                new Claim("id", user.Id.ToString()),
                                new Claim("name", user.Name),
                            };
            extra.Add("user",user);
            if (user !=null)
            {
                context.Result = new GrantValidationResult(user.Id.ToString(), OidcConstants.AuthenticationMethods.Password, claims, customResponse: extra);
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "用户名或密码不正确");
            }
        }
    }
}
