using Services.GeneralServices;
using ServicesAbstraction.GeneralServices;
using Shared.Dtos.Authorization;

namespace Bookiee.Web.Extensions
{

    public static class CoreServicesExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddAutoMapper(typeof(BookProfile).Assembly);

            
            services.AddScoped<IAttatchementService, AttatchementService>();

            services.Configure<JwtOption>(configuration.GetSection("JwtOptions"));
            return services;
        }

    }
}