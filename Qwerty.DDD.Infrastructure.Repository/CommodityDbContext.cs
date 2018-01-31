using System.Reflection;
using Qwerty.DDD.Infrastructure;
using Framework.Infrastructure.Interfaces.Core;
using Microsoft.EntityFrameworkCore;

namespace Qwerty.DDD.Infrastructure.Repository
{
    public class CommodityDbContext : DbContext, IDbContext
    {
        public CommodityDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().GetTypeInfo().Assembly);
        }
    }
}
