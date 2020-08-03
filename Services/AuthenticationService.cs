using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleAuthAPI.Configuration;
using SimpleAuthAPI.Interfaces;
using SimpleAuthAPI.Models;
using SimpleAuthAPI.Requests;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthAPI.Services
{
    public class AuthenticationService : IAuthenticator
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtTokenSettings _jwtTokenSettings;

        public AuthenticationService(UserManager<AppUser> userManager, IOptions<JwtTokenSettings> jwtTokenSettings)
        {
            _jwtTokenSettings = jwtTokenSettings.Value;
            _userManager = userManager;
        }

        public async Task<IdentityResult> Register(RegisterRequest request)
        {
            var appUser = new AppUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, request.Password);
            return result;
        }

        public async Task<string> Login(LoginRequest request)
        {
            AppUser identityUser = await ValidateUser(request);
            if (identityUser != null)
            {
                var token = GenerateToken(identityUser);
                return token;
            }
            return null;
        }

        private async Task<AppUser> ValidateUser(LoginRequest credentials)
        {
            AppUser identityUser = await _userManager.FindByNameAsync(credentials.UserName);
            if (identityUser != null)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, credentials.Password);
                return result == PasswordVerificationResult.Failed ? null : identityUser;
            }
            return null;
        }

        private string GenerateToken(IdentityUser identityUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtTokenSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, identityUser.UserName.ToString()) }),
                Expires = DateTime.UtcNow.AddSeconds(_jwtTokenSettings.ExpiryTimeInSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwtTokenSettings.Audience,
                Issuer = _jwtTokenSettings.Issuer
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
