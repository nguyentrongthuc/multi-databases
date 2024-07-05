using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceCore.Services
{
    public static class CorsServicesRegister
    {
        public static void AddCorsServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddCors(options =>
            {
                string DesktopFrontEndUrl = Configuration.GetValue<string>("DesktopFrontend:url");
                var FrontEndOrigins = Configuration.GetSection("OtherFrontEndOrigins")
                    .GetChildren()
                    .Select(e => e.Value.ToString())
                    .ToList();
                FrontEndOrigins.Add(DesktopFrontEndUrl);
                System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(FrontEndOrigins));
                options.AddPolicy(Configuration.GetValue<string>("DesktopFrontEndClientId"), policy =>
                {
                    policy.WithOrigins(FrontEndOrigins.ToArray())
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }
    }
}