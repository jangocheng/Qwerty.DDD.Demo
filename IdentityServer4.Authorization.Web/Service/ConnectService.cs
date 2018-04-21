using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace IdentityServer4.Authorization.Web.Service
{
    public class ConnectService:IConnectService
    {
        private readonly string _config;
        public ConnectService(IConfiguration config)
        {
            _config = config["data:IssuerUri"];
        }
        public async Task<TokenResponse> GetToken()
        {
            var client = new DiscoveryClient(_config) { Policy = { RequireHttps = false } };
            var disco = await client.GetAsync();
            var tokenClient = new TokenClient(disco.TokenEndpoint, "app.client", "secret");
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("qwerty", "123", "item offline_access");
            //            var reTokenResponse = await tokenClient.RequestRefreshTokenAsync(tokenResponse.RefreshToken);
            return tokenResponse;
        }
    }
}
