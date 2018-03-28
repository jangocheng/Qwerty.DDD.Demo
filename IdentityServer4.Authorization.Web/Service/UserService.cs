using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityServer4.Authorization.Web.Service
{
    public class UserService:IUserService
    {
        public async Task<string> Login(string name, string password)
        {
            using (var client = new HttpClient())
            {
                var response=await client.GetAsync("http://localhost:5001/user/v1/user.inside.login?name="+name+"&password="+password+"");
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
