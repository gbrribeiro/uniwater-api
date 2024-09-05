using Hangfire;
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
    }
}
