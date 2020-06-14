using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Web
{
    public static class WebConfiguration
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {
            services.AddControllers()
                  //.AddFluentValidation(validation => validation.RegisterValidatorsFromAssemblyContaining<Result>())
                    .AddNewtonsoftJson();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
