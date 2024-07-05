using Microsoft.Extensions.DependencyInjection;
using LoggingService.Services;

namespace ServiceCore.Services
{
    public static class ServiceDetailsRegister
    {
        public static void AddServiceDetails(this IServiceCollection services)
        {
            services.AddSelectingLogServices();
            services.AddUpdatingLogServices();
        }
    }
}