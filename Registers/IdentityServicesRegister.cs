using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ServiceCore.Services
{
    public static class IdentityServicesRegister
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration Configuration)
        {
            Console.WriteLine(Configuration.GetValue<string>("ExtendedServiceClientId"));
            string IdentityServerUrl = Configuration.GetValue<string>("IdentityServer:url");
            services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = IdentityServerUrl;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                };
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", Configuration.GetValue<string>("ExtendedServiceClientId"));
                });
            });
        }
    }
}