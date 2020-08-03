using Microsoft.AspNetCore.Identity;
using SimpleAuthAPI.Requests;
using System.Threading.Tasks;

namespace SimpleAuthAPI.Interfaces
{
    public interface IAuthenticator
    {
        public Task<IdentityResult> Register(RegisterRequest request);

        public Task<string> Login(LoginRequest request);
    }
}
