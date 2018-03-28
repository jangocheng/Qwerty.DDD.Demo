using System.Threading.Tasks;

namespace IdentityServer4.Authorization.Web.Service
{
    public interface IUserService
    {
        Task<string> Login(string name, string password);
    }
}
