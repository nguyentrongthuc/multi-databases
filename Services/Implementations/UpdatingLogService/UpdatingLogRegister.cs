using Microsoft.Extensions.DependencyInjection;

namespace LoggingService.Services
{
    public static class UpdatingLogRegister
    {
        public static void AddUpdatingLogServices(this IServiceCollection services)
        {
            services.AddScoped<UpdatingLog1DbService>();
            services.AddScoped<UpdatingLog2DbService>();
            services.AddScoped<UpdatingLog3DbService>();
            services.AddScoped<UpdatingLog4DbService>();
            services.AddTransient<System.Func<string, IUpdatingLogService>>(
            serviceProvider => key =>
            {
                switch (key)
                {
                    case "Log1":
                        return serviceProvider.GetService<UpdatingLog1DbService>();
                    case "Log2":
                        return serviceProvider.GetService<UpdatingLog2DbService>();
                    case "Log3":
                        return serviceProvider.GetService<UpdatingLog3DbService>();
                    case "Log4":
                        return serviceProvider.GetService<UpdatingLog4DbService>();
                    default:
                        return null;
                }
            });
        }
    }
}