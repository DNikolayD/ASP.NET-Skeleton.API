using ASP.NET_Skeleton.Data.Repositories;

namespace ASP.NET_Skeleton.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddLogging();
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
        }
    }
}
