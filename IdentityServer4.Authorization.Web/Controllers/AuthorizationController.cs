using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityServer4.Authorization.Web.Controllers
{
    [Route("authorization/v1")]
    public class AuthorizationController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        [Route("authorization.token.get")]
        public async Task<IActionResult> Get()
        {
            var client = new DiscoveryClient($"http://localhost:5000/") { Policy = { RequireHttps = false } };
            var disco = await client.GetAsync();
            var tokenClient = new TokenClient(disco.TokenEndpoint, "app.client", "secret");
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("qwerty", "123", "item offline_access");

//            var reTokenResponse = await tokenClient.RequestRefreshTokenAsync(tokenResponse.RefreshToken);
            return Ok(new { is_success = true, token = tokenResponse });
        }
       
    }
}
