using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SimpleAuthAPI.Configuration;
using System.Text;

namespace SimpleAuthAPI.Middleware
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var jwtSection = config.GetSection("JwtTokenSettings");
            services.Configure<JwtTokenSettings>(jwtSection);
            var jwtTokenSettings = jwtSection.Get<JwtTokenSettings>();
            var key = Encoding.ASCII.GetBytes(jwtTokenSettings.SecretKey);

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = jwtTokenSettings.Issuer,
                        ValidAudience = jwtTokenSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                    };
                });
            return services;
        }
    }
}
