using ASP.NET_Skeleton.Common;
using ASP.NET_Skeleton.Data;
using ASP.NET_Skeleton.Data.Repositories;
using ASP.NET_Skeleton.Service.InjectionTypes;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ASP.NET_Skeleton.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCustomDb(configuration);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddLogging();
            services.AddScoped(typeof(IBaseRepository), typeof(BaseRepository<,>));
            services.AddTransient(typeof(BaseFactory<>), typeof(BaseFactory<>));
            services.AddServices();
        }

        private static void AddCustomDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .LogTo(message => File.AppendAllText(Path.Combine(Assembly.GetExecutingAssembly().Location, @"..\..\..\..\logs.txt"), message)));
        }

        private static void AddServices(this IServiceCollection services)
        {
            var serviceInterfaceType = typeof(IService);
            var serviceSingletonInterfaceType = typeof(ISingletonService);
            var serviceScopedInterfaceType = typeof(IScopedService);
            var types = serviceInterfaceType.Assembly
                .GetExportedTypes()
                .Where(x => x.IsClass && !x.IsAbstract)
                .Select(x => new
                {
                    Service = x.GetInterface($"I{x.Name}"),
                    Implementation = x
                })
                .Where(x => x.Service != null);

            foreach (var type in types)
            {
                if (serviceInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }
                else if (serviceSingletonInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddSingleton(type.Service, type.Implementation);
                }
                else if (serviceScopedInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddScoped(type.Service, type.Implementation);
                }
            }
        }
    }
}
