using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleAuthAPI.Database;
using SimpleAuthAPI.Interfaces;
using SimpleAuthAPI.Middleware;
using SimpleAuthAPI.Models;
using SimpleAuthAPI.Services;
using SimpleAuthAPI.Services.Repositories;

namespace SimpleAuthAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAuthenticator, AuthenticationService>();
            services.AddScoped<IBuslineRepository, BuslineRepository>();
            services.AddScoped<ITest1Repository, Test1Repository>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:*")
                        .SetIsOriginAllowedToAllowWildcardSubdomains();
                    });
            });
            services.AddControllers();

            services.AddDbContext<AuthDbContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("SqlConnection"), db => db.UseNetTopologySuite()));

            services.AddDbContext<LargeDataContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("LargeDataConnection")));

            services.AddIdentity<AppUser, IdentityRole>(options => options
                .SignIn.RequireConfirmedAccount = true)
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AuthDbContext>();

            services.AddTokenAuthentication(Configuration);

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
