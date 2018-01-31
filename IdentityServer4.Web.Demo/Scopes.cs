using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServer4.Web.Demo
{
    internal class Scopes
    {
        public static IEnumerable<IdentityResource> GetIdentityScopes()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Address(),
                new IdentityResource("roles", new[] { "role" })
            };
        }

        public static IEnumerable<ApiResource> GetApiScopes()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "api",
                    ApiSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    Scopes =
                    {
                        new Scope
                        {
                            Name = "api1"
                        },
                        new Scope
                        {
                            Name = "api2"
                        },
                        new Scope
                        {
                            Name = "api3"
                        },
                        new Scope
                        {
                            Name = "api4.with.roles",
                            UserClaims = { "role" }
                        }
                    }
                }
            };
        }
    }
}
