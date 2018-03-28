using System.Collections.Generic;
using System.Linq;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer4.Authorization.Web
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            var apis = new List<string>();
            Scopes.GetApiScopes().ToList().ForEach(x => apis.Add(x.Name));
            apis.Add(IdentityServerConstants.StandardScopes.OfflineAccess);
            apis.Add(IdentityServerConstants.StandardScopes.OpenId);
            apis.Add(IdentityServerConstants.StandardScopes.Profile);

            return new List<Client>
            {
                new Client
                {
                    ClientId = "service.client",
                    ClientSecrets = {new Secret("secret".Sha256())},
                      AllowOfflineAccess=true,
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = apis
                },
                new Client
                {
                    ClientId = "app.client",
                    ClientSecrets ={new Secret("secret".Sha256())},
                    AllowOfflineAccess = true,
//                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
//                    RefreshTokenExpiration = TokenExpiration.Sliding,
//                    UpdateAccessTokenClaimsOnRefresh = true,
//                    AccessTokenLifetime = Convert.ToInt32(TimeSpan.FromMinutes(16).TotalSeconds),
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = apis
                },
                new Client
                {
                    ClientId = "web.client",
                    ClientSecrets ={new Secret("secret".Sha256())},
                    AllowOfflineAccess = true,
//                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
//                    RefreshTokenExpiration = TokenExpiration.Sliding,
//                    UpdateAccessTokenClaimsOnRefresh = true,
//                    AccessTokenLifetime = Convert.ToInt32(TimeSpan.FromMinutes(16).TotalSeconds),
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = apis
                },
                 new Client
                {
                    ClientId = "h5.client",
                    ClientSecrets ={new Secret("secret".Sha256())},
                    AllowOfflineAccess = true,
//                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
//                    RefreshTokenExpiration = TokenExpiration.Sliding,
//                    UpdateAccessTokenClaimsOnRefresh = true,
//                    AccessTokenLifetime = Convert.ToInt32(TimeSpan.FromMinutes(16).TotalSeconds),
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = apis
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

                    AllowedScopes =apis
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

                    AllowedScopes =apis
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
