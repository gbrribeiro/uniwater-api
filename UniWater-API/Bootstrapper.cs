using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using UniWater_API.Data.Repositories;
using UniWater_API.Data.Repositories.Interfaces;
using UniWater_API.Worker;
using UniWater_API.Worker.Interfaces;

namespace UniWater_API
{
    public static class Bootstrapper
    {

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IRecordingRepository, RecordingRepository>();
            services.AddScoped<ISystemRepository, SystemRepository>();
            services.AddScoped<IStreamingDataRepository, StreamingDataRepository>();
            services.AddScoped<IBatchFactory, BatchFactory>();

            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseInMemoryStorage());

            services.AddHangfireServer();

            return services;
        }

        public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            //IdentityConfiguration
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });


            return services;
        }
    }
}
