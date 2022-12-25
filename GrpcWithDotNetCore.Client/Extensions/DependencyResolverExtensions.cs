using GrpcWithDotNetCore.Client.Interfaces;
using GrpcWithDotNetCore.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GrpcWithDotNetCore.Client.Extensions
{
    public static class DependencyResolverExtensions
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services)
        {
            string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var appsettingsfile = string.IsNullOrEmpty(environment) ? "appsettings.json" : $"appsettings.{environment}.json";

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile(appsettingsfile)
                .AddEnvironmentVariables()
                .Build();

            services
                    .AddScoped<IGreeterService, GreeterService>()
                    .AddSingleton(configuration);

            return services;
        }
    }
}
