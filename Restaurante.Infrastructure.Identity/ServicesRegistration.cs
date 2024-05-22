using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestaurantApi.Core.Domain.Settings;
using Restaurante.Core.Application.Dtos.Account;
using Restaurante.Core.Application.Interfaces.Services;
using Restaurante.Infrastructure.Identity.Contexts;
using Restaurante.Infrastructure.Identity.Entities;
using Restaurante.Infrastructure.Identity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Infrastructure.Identity
{
    public static class ServicesRegistration
    {
        public static void AddIdentityInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {

            #region Contexts

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                service.AddDbContext<IdentityContext>(options => options.UseInMemoryDatabase("IdentityMemory"));
            }
            else
            {
                service.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"),
                m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));
            }
            #endregion

            #region Identity
            service.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

            service.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/User/Login";
                options.AccessDeniedPath = "/User/AccessDenied";
            });

            service.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));

            service.AddAuthentication(options =>
            {

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {

                options.RequireHttpsMetadata = false;
                options.SaveToken = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,

                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    ValidAudience = configuration["JWTSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
                };

                options.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();
                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";
                        return c.Response.WriteAsync(c.Exception.ToString());
                    },

                    OnChallenge = c =>
                    {
                        c.HandleResponse();
                        c.Response.StatusCode = 401;
                        c.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(new JwtResponse() { HasError = true, Error = "You are not authorized" });
                        return c.Response.WriteAsync(result);
                    },

                    OnForbidden = c =>
                    {
                        c.Response.StatusCode = 403;
                        c.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(new JwtResponse() { HasError = true, Error = "You are not authorized to access this resources" });
                        return c.Response.WriteAsync(result);
                    }

                };

            });


            #endregion

            #region Services

            service.AddTransient<IUsuarioService, AccountServices>();

            #endregion

        }
    }
}