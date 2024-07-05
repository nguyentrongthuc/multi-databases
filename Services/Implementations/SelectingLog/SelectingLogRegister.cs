using Microsoft.Extensions.DependencyInjection;

namespace LoggingService.Services
{
    public static class SelectingLogRegister
    {
        public static void AddSelectingLogServices(this IServiceCollection services)
        {
            services.AddScoped<Log1DbService>();
            services.AddScoped<Log2DbService>();
            services.AddScoped<Log3DbService>();
            services.AddScoped<Log4DbService>();
            services.AddTransient<System.Func<string, ILogService>>(
            serviceProvider => key =>
            {
                switch (key)
                {
                    case "Log1":
                        return serviceProvider.GetService<Log1DbService>();
                    case "Log2":
                        return serviceProvider.GetService<Log2DbService>();
                    case "Log3":
                        return serviceProvider.GetService<Log3DbService>();
                    case "Log4":
                        return serviceProvider.GetService<Log4DbService>();
                    default:
                        return null;
                }
            });
        }
    }
}