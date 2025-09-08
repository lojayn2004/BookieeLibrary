

using Microsoft.OpenApi.Models;

namespace Bookiee.Web.Extensions
{

    public static class PresentationServicesExtensions
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
            {
                
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                         new OpenApiSecurityScheme
                         {
                              Reference = new OpenApiReference
                              {
                                    Type=ReferenceType.SecurityScheme,
                                    Id="Bearer"
                              }
                         },
                         new string[]{}
                    }
                 });
            });
            return services;
        }
    }
}