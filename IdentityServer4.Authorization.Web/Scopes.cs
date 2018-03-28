using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServer4.Authorization.Web
{
    internal class Scopes
    {
        public static IEnumerable<IdentityResource> GetIdentityScopes()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiScopes()
        {
            return new List<ApiResource>
            {
                new ApiResource("item", "商品"){ UserClaims = new List<string> {"role"}},
                new ApiResource("logistics", "物流"){ UserClaims = new List<string> {"role"}},
                new ApiResource("user", "用户"){ UserClaims = new List<string> {"role"}},
            };
        }
    }
}
