using Qwerty.DDD.Infrastructure.Repository;
using Framework.Infrastructure.Core;
using Framework.Infrastructure.Interfaces.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Qwerty.DDD.Application.Interfaces.UserServiceInterfaces;
using Qwerty.DDD.Application.UserServices;
using Qwerty.DDD.Domain.Repository.Interfaces.UserRepositoryInterfaces;
using Qwerty.DDD.Repository.UserRepository;

namespace Qwerty.DDD.BootStrapping
{
    public static class Startup
    {
        public static void Configure(this IServiceCollection service, string connectionString)
        {
            service.AddEntityFrameworkSqlServer().AddDbContext<CommodityDbContext>(options => options.UseSqlServer(connectionString));

            //service.AddDbContext<CommodityDbContext>(options =>options.UseMySQL(connectionString));

            service.AddTransient<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IDbContext, CommodityDbContext>();
            service.AddSingleton<IWorkContext, WorkContext>();

            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IUserService, UserService>();
        }
    }
}
