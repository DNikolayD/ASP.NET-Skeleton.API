using ASP.NET_Skeleton.Common;
using ASP.NET_Skeleton.Data.Factories;
using ASP.NET_Skeleton.Data.Requests;
using ASP.NET_Skeleton.Data.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ASP.NET_Skeleton.Data.Repositories
{
    public class BaseRepository<TClass, TFactory> : IBaseRepository<TClass, TFactory> where TClass : class , TFactory where TFactory : DataEntityFactory<TClass>
    {
        private readonly DbSet<TClass> _table;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BaseRepository<TClass, TFactory>> _logger;
        private readonly DataEntityFactory<TClass> _factory;

        public BaseRepository(ApplicationDbContext applicationDbContext, ILogger<BaseRepository<TClass, TFactory>> logger)
        {
            var context = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
            _context = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
            _logger = logger;
            _factory = new DataEntityFactory<TClass>();
            _table = context.Set<TClass>();
        }

        public async Task<BaseDataResponse> GetAllAsync()
        {
            var baseFactory = new BaseFactory<BaseDataResponse>();
            var response = baseFactory.InitialiseEntity(new List<KeyValuePair<string, object>>()
                {new("Object", $"{this.GetType().Name}, GetAllAsync")});
            var entities = await _table.ToListAsync();
            foreach (var entity in entities)
            {
                _factory.Validate(entity);
                if (!_factory.Validator.Errors.Any()) continue;
                response!.Payload = string.Empty;
                response.Errors.AddRange(_factory.Validator.Errors);
            }

            response!.IsSuccessful = !response.Errors.Any();
            if (response.IsSuccessful)
            {
                response.Payload = entities;
            }

            _logger.LogInformation(response.GetMessage());
            return response;
        }

        public async Task<BaseDataResponse> GetByIdAsync(BaseDataRequest request)
        {
            var baseFactory = new BaseFactory<BaseDataResponse>();
            var response = baseFactory.InitialiseEntity(new List<KeyValuePair<string, object>>()
                {new("Object", $"{this.GetType().Name}, GetIdAsync")});
            var entity = await _table.FindAsync(request.Payload);
            _factory.Validate(entity!);
            response!.Payload = string.Empty;
            response.Errors.AddRange(_factory.Validator.Errors);
            response!.IsSuccessful = !response.Errors.Any();
            if (response.IsSuccessful)
            {
                response.Payload = entity!;
            }

            _logger.LogInformation(response.GetMessage());
            return response;
        }

        public async Task<BaseDataResponse> InsertAsync(BaseDataRequest request)
        {
            var baseFactory = new BaseFactory<BaseDataResponse>();
            var response = baseFactory.InitialiseEntity(new List<KeyValuePair<string, object>>()
                {new("Object", $"{this.GetType().Name}, InsertAsync")});
            var entity = (TClass)request.Payload.MapTo(typeof(TClass));
            _factory.Validator.Validate(entity);
            response!.Errors.AddRange(_factory.Validator.Errors);
            response!.IsSuccessful = !response.Errors.Any();
            if (response.IsSuccessful)
            {
                await _table.AddAsync(entity);
                response.Payload = _table.Contains(entity);
            }
            _logger.LogInformation(response.GetMessage());
            return response;
        }

        public BaseDataResponse Update(BaseDataRequest request)
        {
            var baseFactory = new BaseFactory<BaseDataResponse>();
            var response = baseFactory.InitialiseEntity(new List<KeyValuePair<string, object>>()
                {new("Object", $"{this.GetType().Name}, UpdateAsync")});
            var entity = (TClass)request.Payload.MapTo(typeof(TClass));
            _factory.Validator.Validate(entity);
            if (_factory.Validator.Errors.Any())
            {
                response.Errors.AddRange(_factory.Validator.Errors);
            }

            response.IsSuccessful = !response.Errors.Any();
            if (response.IsSuccessful)
            {
                _table.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                response.Payload = _table.Contains(entity);
            }
            _logger.LogInformation(response.GetMessage());
            return response;
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
