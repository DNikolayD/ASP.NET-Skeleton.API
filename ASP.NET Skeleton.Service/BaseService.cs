using ASP.NET_Skeleton.Common;
using ASP.NET_Skeleton.Data.Repositories;
using Microsoft.Extensions.Logging;

namespace ASP.NET_Skeleton.Service
{
    public class BaseService<TFactory, TClass> : IBaseService where TFactory : BaseFactory<TClass>, TClass where TClass : class
    {
        private readonly IBaseRepository _repository;

        private readonly TFactory _factory;

        private readonly ILogger<BaseService<TFactory, TClass>> _logger;

        private readonly BaseFactory<BaseResponse> _baseFactory = new();

        public BaseService(IBaseRepository repository, TFactory factory, ILogger<BaseService<TFactory, TClass>> logger)
        {
            _repository = repository;
            _factory = factory;
            _logger = logger;
        }

        public async Task<BaseResponse> AddAsync(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> RemoveAsync(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> UpdateAsync(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> GetAsync(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> GetMany(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> GetSortedAsync(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> GetFilteredAsync(BaseRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
