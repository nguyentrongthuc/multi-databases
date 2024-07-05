using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceCore.Models;
using ServiceCore.Services;

namespace LoggingService
{
    public class Startup
    {
        private readonly string LoggingService1ConnectionString = "LoggingService1ConnectionString";
        private readonly string LoggingService2ConnectionString = "LoggingService2ConnectionString";
        private readonly string LoggingService3ConnectionString = "LoggingService3ConnectionString";
        private readonly string LoggingService4ConnectionString = "LoggingService4ConnectionString";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddDbContext<Log1ApplicationDbContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString(LoggingService1ConnectionString)), ServiceLifetime.Transient);
            services.AddDbContext<Log2ApplicationDbContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString(LoggingService2ConnectionString)), ServiceLifetime.Transient);
            services.AddDbContext<Log3ApplicationDbContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString(LoggingService3ConnectionString)), ServiceLifetime.Transient);
            services.AddDbContext<Log4ApplicationDbContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString(LoggingService4ConnectionString)), ServiceLifetime.Transient);

            services.AddCorsServices(Configuration);
            services.AddIdentityServices(Configuration);
            services.AddSwaggerRegister();
            services.AddServiceDetails();

            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(@"share"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LoggingService API version 1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
