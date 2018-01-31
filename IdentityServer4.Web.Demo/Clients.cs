using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServer4.Web.Demo
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "service.client",
                    ClientSecrets = {new Secret("secret".Sha256())},
                      AllowOfflineAccess=true,
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"api1", "api2.read_only"}
                },
                 new Client
                {
                    ClientId = "ro.Client",
                    ClientSecrets ={new Secret("secret".Sha256())},
                    AllowOfflineAccess = true,
//                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
//                    RefreshTokenExpiration = TokenExpiration.Sliding,
//                    UpdateAccessTokenClaimsOnRefresh = true,
//                    AccessTokenLifetime = Convert.ToInt32(TimeSpan.FromMinutes(16).TotalSeconds),
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = { "api1","api2.read_only" }
                },
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    ClientUri = "http://identityserver.io",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = {"http://localhost:7017/index.html"},
                    PostLogoutRedirectUris = {"http://localhost:7017/index.html"},
                    AllowedCorsOrigins = {"http://localhost:7017"},

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "api1",
                        "api2.read_only"
                    }
                },
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    ClientUri = "http://identityserver.io",

                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowOfflineAccess = true,
                    ClientSecrets = {new Secret("secret".Sha256())},

                    RedirectUris = {"http://localhost:21402/signin-oidc"},
                    PostLogoutRedirectUris = {"http://localhost:21402/"},
                    FrontChannelLogoutUri = "http://localhost:21402/signout-oidc",

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "api1",
                        "api2.read_only"
                    },
                }
            };
        }

        public static List<TestUser> GeTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "qwerty",
                    Password = "a123"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "aspros",
                    Password = "b123"
                }
            };
        }
    }
}
