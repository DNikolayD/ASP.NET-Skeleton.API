using ASP.NET_Skeleton.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ASP.NET_Skeleton.Data.Repositories
{
    public sealed class BaseRepository<TClass, TFactory> : IBaseRepository where TClass : class, TFactory where TFactory : BaseFactory<TClass>
    {
        private readonly DbSet<TClass> _table;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BaseRepository<TClass, TFactory>> _logger;
        private readonly TFactory _factory;
        private readonly ResponseFactory _responseFactory = new();

        public BaseRepository(ApplicationDbContext applicationDbContext, TFactory factory, ILogger<BaseRepository<TClass, TFactory>> logger)
        {
            var context = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
            _context = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
            _logger = logger;
            _factory = factory;
            _table = context.Set<TClass>();
        }

        public BaseResponse GetMany(BaseRequest request)
        {
            var amount = int.Parse(request.Payload.ToString()!);
            var origin = $"{this.GetType().Name}, GetMany";
            var response = _responseFactory.InitialiseEntity(origin);
            FormattableString query = $"SELECT TOP {amount} FROM {typeof(TClass).Name}";
            var entities = _table.FromSql(query);
            response!.Payload = entities;
            _logger.LogInformation(response.GetMessage());
            return response;
        }

        public BaseResponse GetById(BaseRequest request)
        {
            var origin = $"{this.GetType().Name}, GetId";
            var response = _responseFactory.InitialiseEntity(origin);
            FormattableString query = $"SELECT * WHERE Id = {request.Payload} FROM {typeof(TClass).Name}";
            var entity = _table.FromSql(query);
            response!.Payload = entity;
            _logger.LogInformation(response.GetMessage());
            return response;
        }

        public async Task<BaseResponse> InsertAsync(BaseRequest request)
        {
            var origin = $"{this.GetType().Name}, InsertAsync";
            var response = _responseFactory.InitialiseEntity(origin);
            var entity = request.Payload.MapTo<TClass>();
            _factory.Validator.Validate(entity);
            response!.Errors.AddRange(_factory.Validator.Errors);
            response.IsSuccessful = !response.Errors.Any();
            if (response.IsSuccessful)
            {
                await _table.AddAsync(entity);
                response.Payload = _table.Contains(entity);
            }
            _logger.LogInformation(response.GetMessage());
            return response;
        }

        public BaseResponse Update(BaseRequest request)
        {
            var origin = $"{this.GetType().Name}, Update";
            var response = _responseFactory.InitialiseEntity(origin);
            var entity = request.Payload.MapTo<TClass>();
            _factory.Validator.Validate(entity);
            if (_factory.Validator.Errors.Any())
            {
                response!.Errors.AddRange(_factory.Validator.Errors);
            }
            response!.IsSuccessful = !response.Errors.Any();
            if (response.IsSuccessful)
            {
                _table.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                response.Payload = _table.Contains(entity);
            }
            _logger.LogInformation(response.GetMessage());
            return response;
        }

        public BaseResponse Delete(BaseRequest request)
        {
            var origin = $"{this.GetType().Name}, Delete";
            var response = _responseFactory.InitialiseEntity(origin);
            var entity = (TClass)GetById(request).Payload;
            typeof(TClass).GetProperties().Where(p => p.CanWrite && p.CanRead && p.Name.EndsWith("Id") && p.Name != "Id").ToList().ForEach(p => p.SetValue(p, null));
            _table.Remove(entity);
            response!.IsSuccessful = !_table.Contains(entity);
            response.Payload = !_table.Contains(entity);
            _logger.LogInformation(response.GetMessage());
            return response;
        }

        public async Task<BaseResponse> SaveAsync()
        {
            var origin = $"{this.GetType().Name}, SaveAsync";
            var response = _responseFactory.InitialiseEntity(origin);
            var changes = await _context.SaveChangesAsync();
            response!.IsSuccessful = changes > 0;
            response.Payload = changes;
            _logger.LogInformation(response.GetMessage());
            return response;
        }

        public BaseResponse Filter(BaseRequest request)
        {
            var origin = $"{this.GetType().Name}, Filter";
            var response = _responseFactory.InitialiseEntity(origin);
            var filter = request.Payload.MapTo<FilteringObject>();
            var propertyName = filter.PropertyName;
            var value = filter.Value;
            FormattableString query = $"SELECT TOP {filter.Amount} FROM {typeof(TClass).Name} WHERE {propertyName} = '{value}'";
            var all = _table.FromSql(query);
            response!.IsSuccessful = true;
            response.Payload = all;
            _logger.LogInformation(response.GetMessage());
            return response;
        }

        public BaseResponse Sort(BaseRequest request)
        {
            var origin = $"{this.GetType().Name}, Sort";
            var response = _responseFactory.InitialiseEntity(origin);
            var filter = request.Payload.MapTo<FilteringObject>();
            var propertyName = filter.PropertyName;
            FormattableString query = $"SELECT TOP {filter.Amount} ORDER BY {propertyName}";
            var all = _table.FromSql(query);
            response!.IsSuccessful = true;
            response.Payload = all;
            _logger.LogInformation(response.GetMessage());
            return response;
        }
    }
}
