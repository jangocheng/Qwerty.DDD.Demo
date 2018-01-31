using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
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
            var user = new User { Id = 3, Name = "Q" };
            var result = await _userService.Delete(user);
        }
    }
}
