using Contracts;
using LoggerService;
using Repository;
using Microsoft.EntityFrameworkCore;

namespace ExerciseLogger.Extensions
{
    public static class ServiceExtensions
    {
        //Cors configuration give or restrict access to application from different domains
        //For production restrictions are necessary
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        //IIS configuration 
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => {});

        //Logger service configuration, one instance created and called when needed
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}
