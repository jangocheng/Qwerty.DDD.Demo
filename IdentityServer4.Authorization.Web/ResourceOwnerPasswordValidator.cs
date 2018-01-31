using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace IdentityServer4.Authorization.Web
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
//        private readonly IUserService _userService;
//
//        public ResourceOwnerPasswordValidator(IUserService userService)
//        {
//            _userService = userService;
//        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if(context.UserName=="qwerty" && context.Password=="qqq")
//            if (await _userService.ValiedUser(context.UserName, context.Password))
            {
                context.Result = new GrantValidationResult("", OidcConstants.AuthenticationMethods.Password);
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "用户名或密码不正确");
            }
        }
    }
}
