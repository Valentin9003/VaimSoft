using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddDatabase(configuration);

        private static IServiceCollection AddDatabase(
       this IServiceCollection services,
       IConfiguration configuration) => 
            services
                .AddDbContext<VaimSoftDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(VaimSoftDbContext)
                                .Assembly.FullName)))
                .AddTransient<IInitializer, VaimSoftDbInitializer>();

    }

    //private static IServiceCollection AddIdentity(
    //       this IServiceCollection services,
    //       IConfiguration configuration)
    //{
    //    services
    //        .AddIdentity<User, IdentityRole>(options =>
    //        {
    //            options.Password.RequiredLength = 6;
    //            options.Password.RequireDigit = false;
    //            options.Password.RequireLowercase = false;
    //            options.Password.RequireNonAlphanumeric = false;
    //            options.Password.RequireUppercase = false;
    //        })
    //        .AddEntityFrameworkStores<CarRentalDbContext>();

    //    var secret = configuration
    //        .GetSection(nameof(ApplicationSettings))
    //        .GetValue<string>(nameof(ApplicationSettings.Secret));

    //    var key = Encoding.ASCII.GetBytes(secret);

    //    services
    //        .AddAuthentication(authentication =>
    //        {
    //            authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //            authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //        })
    //        .AddJwtBearer(bearer =>
    //        {
    //            bearer.RequireHttpsMetadata = false;
    //            bearer.SaveToken = true;
    //            bearer.TokenValidationParameters = new TokenValidationParameters
    //            {
    //                ValidateIssuerSigningKey = true,
    //                IssuerSigningKey = new SymmetricSecurityKey(key),
    //                ValidateIssuer = false,
    //                ValidateAudience = false
    //            };
    //        });

    //    //services.AddTransient<IIdentity, IdentityService>();
    //    //services.AddTransient<IJwtTokenGenerator, JwtTokenGeneratorService>();

    //    return services;
    //}
}
