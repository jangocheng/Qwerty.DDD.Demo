using System.Linq;
using Framework.Infrastructure.Interfaces.Core;
using Framework.Infrastructure.Repository.Core;
using Qwerty.DDD.Domain;
using Qwerty.DDD.Domain.Repository.Interfaces.UserRepositoryInterfaces;

namespace Qwerty.DDD.Repository.UserRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        public IQueryable<User> GetIdentityById(long id)
        {
            return Entities.Where(i => i.Id == id);
        }
    }
}
