using System.Threading.Tasks;
using IdentityModel.Client;

namespace IdentityServer4.Authorization.Web.Service
{
    public interface IConnectService
    {
        Task<TokenResponse> GetToken();
    }
}
