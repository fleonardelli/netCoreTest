using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using api.Models;
using api.Exceptions;
using api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using api.Repository;
using Microsoft.AspNetCore.Identity;

namespace api
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
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IExternalTokenValidator, ExternalGoogleTokenValidatorService>();
            services.AddScoped<IAuthenticationManager, JwtAuthenticationManager>();
            services.AddScoped<DeviceService>();
            services.AddScoped<UserDeviceActionRepository>();
            services.AddScoped<UserRoleRepository>();
            services.AddScoped<DeviceRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<UserService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    }
                );

            services.AddMvc();
            services.AddHttpContextAccessor();

            var server = Configuration["DB_SERVER"];
            var port = Configuration["DB_PORT"];
            var user = Configuration["DB_USER"];
            var password = Configuration["DB_PASSWORD"];
            var db = Configuration["DB_NAME"];

            if (server == null || port == null || user == null || password == null || db == null) {
                throw (new MisconfiguredDatabaseConnectionException());
            }
            services.AddDbContext<IotHomeControlContext>(options =>
                options.UseMySql($"server={server};port={port};database={db};user={user};password={password}"));
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
