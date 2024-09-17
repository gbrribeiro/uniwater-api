using Compacts.Simple.Identity.EF.Implementations;
using Compacts.Simple.Identity.EF.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Compacts.Simple.Identity.EF.Extensions
{
    public static class ServiceExtension
    {
        /// <summary>
        /// Configures the JWT based on the appsettings.json.
        /// Add authentication too.
        /// </summary>
        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            //This variable holds the information from the JwtOptions from appsettings.json
            var jwtOptionsSettings = configuration.GetSection("JwtOptions");
            //Creates the encrypted security key
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("JwtOptions:SecurityKey").Value));

            //Configures an option class, in this case the JwtOption
            services.Configure<Jwt>(jwtOptions =>
            {
                jwtOptions.Issuer = jwtOptionsSettings["Issuer"];
                jwtOptions.Audience = jwtOptionsSettings["Audience"];
                jwtOptions.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                jwtOptions.Expiration = int.Parse(jwtOptionsSettings["Expiration"]);
            });

            //Configures an option class, in this case the IdentityOptions
            //Sets the password min lenght
            services.Configure<IdentityOptions>(identityOptions =>
            {
                identityOptions.Password.RequiredLength = 4;
            });

            //Creates the token validation parameter
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtOptionsSettings["Issuer"],

                ValidateAudience = true,
                ValidAudience = jwtOptionsSettings["Audience"],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt => opt.TokenValidationParameters = tokenValidationParameters);

            services.AddAuthorization();

            return services;
        }

        public static IServiceCollection AddJwtVerificationSwagger(this IServiceCollection services)
        {
            //Modify swagger generation to accept a token
            services.AddSwaggerGen(options =>
            {
                //Add the security token configuration
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }

        public static IServiceCollection AddCompactIdentity<TUser, TRole, TContext>(this IServiceCollection services, Action<DbContextOptionsBuilder>? dbConfig) 
            where TUser : IdentityUser
            where TRole : IdentityRole
            where TContext : IdentityDbContext<TUser>
        {
            //Add default identity
            services.AddIdentity<TUser, TRole>()
                .AddEntityFrameworkStores<TContext>()
                .AddDefaultTokenProviders();

            //Add context
            services.AddDbContext<TContext>(dbConfig);

            //Add services
            services.AddScoped<IIdentityControlService<TUser>, IdentityControlService<TUser>>();

            return services;
        }
    }
}