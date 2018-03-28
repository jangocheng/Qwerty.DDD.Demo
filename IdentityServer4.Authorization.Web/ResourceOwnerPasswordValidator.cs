using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Authorization.Web.Model;
using IdentityServer4.Authorization.Web.Service;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Newtonsoft.Json;

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
            var result = await _userService.Login(context.UserName, context.Password);
            var strResult = JsonConvert.DeserializeObject<SubmitResult>(result);
            var extra = new Dictionary<string, object>();
            var claims = new List<Claim>()
                            {
                                new Claim("id", ""),
                                new Claim("name", ""),
                            };
            extra.Add("user",strResult.Data);
            if (strResult.Succeed)
            {
                context.Result = new GrantValidationResult("", OidcConstants.AuthenticationMethods.Password, claims, customResponse: extra);
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "用户名或密码不正确");
            }
        }
    }
}
