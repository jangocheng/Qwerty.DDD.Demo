using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.EntityFrameworkCore;
using Qwerty.DDD.Application.Interfaces.UserServiceInterfaces;
using Qwerty.DDD.Domain;
using Qwerty.DDD.Domain.Repository.Interfaces.UserRepositoryInterfaces;
using Xunit;
using Xunit.Abstractions;
using XUnitTest;

namespace UserTests
{
    public class UnitTest1 : BaseTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        public UnitTest1(ITestOutputHelper output) : base(output)
        {
            _userRepository = Provider.GetService<IUserRepository>();
            _userService = Provider.GetService<IUserService>();
        }

        [Fact]
        public async Task Test2()
        {
            var user = await _userRepository.GetIdentityById(2).FirstOrDefaultAsync();
            Console.Write(user);
        }

        [Fact]
        public async Task Test3()
        {
            var user = new User();
            var result = await _userService.Delete(user);
        }

        [Fact]
        public async Task Test4()
        {
            var client = new DiscoveryClient($"http://localhost:5000/") { Policy = { RequireHttps = false } };
            var disco = await client.GetAsync();
            var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.Client", "secret");
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("qwerty", "a123", "api1 offline_access");

            var reTokenResponse = await tokenClient.RequestRefreshTokenAsync(tokenResponse.RefreshToken);

        }
    }
}
