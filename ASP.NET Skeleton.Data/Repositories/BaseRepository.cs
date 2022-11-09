using ASP.NET_Skeleton.Data.Requests;
using ASP.NET_Skeleton.Data.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ASP.NET_Skeleton.Data.Repositories
{
    public class BaseRepository<TClass> : IBaseRepository<TClass> where TClass : class
    {
        private readonly DbSet<TClass> _table;
        private readonly ILogger<BaseRepository<TClass>> _logger;
        
        public BaseRepository(ApplicationDbContext applicationDbContext, ILogger<BaseRepository<TClass>> logger)
        {
            var context = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
            _logger = logger;
            _table = context.Set<TClass>();
        }

        public async Task<BaseDataResponse> GetAllAsync()
        {
            var response = new BaseDataResponse()
            {
                Origin = $"{this.GetType().Name}, GetAllAsync"
            };
            var entities = await _table.ToListAsync();

            response.IsSuccessful = !response.Errors.Any();
            if (response.IsSuccessful)
            {
                response.Payload = entities;
            }
            //_logger.Log();
            return response;
        }

        public Task<BaseDataResponse> GetByIdAsync(BaseDataRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseDataResponse> InsertAsync(BaseDataRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseDataResponse> UpdateAsync(BaseDataRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseDataResponse> DeleteAsync(BaseDataRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseDataResponse> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BaseDataResponse> FilterAsync(BaseDataRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
