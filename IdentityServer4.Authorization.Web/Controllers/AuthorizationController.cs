using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
using IdentityServer4.Authorization.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityServer4.Authorization.Web.Controllers
{
    [Route("authorization/v1")]
    public class AuthorizationController : Controller
    {
        private readonly IConnectService _connectService;
        public AuthorizationController(IConnectService connectService)
        {
            _connectService = connectService;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("authorization.token.get")]
        public async Task<IActionResult> Get()
        {
            var tokenResponse = await _connectService.GetToken();

            return Ok(new { is_success = true, token = tokenResponse });
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("authorization.token.get1")]
        public async  Task<IActionResult> Get1()
        {
            return Ok(new{data="1"});
        }

    }
}
