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

        public BaseService(IBaseRepository repository, TFactory factory, ILogger<BaseService<TFactory, TClass>> logger)
        {
            _repository = repository;
            _factory = factory;
            _logger = logger;
        }

        public async Task<BaseResponse> AddAsync(BaseRequest request)
        {
            var origin = $"{this.GetType().Name}, AddAsync";
            request.Origin = origin;
            var response = await _repository.InsertAsync(request);
            _factory.Validator.Validate(response);
            _logger.LogInformation(response.GetMessage());
            return response;
        }

        public BaseResponse Remove(BaseRequest request)
        {
            var origin = $"{this.GetType().Name}, Remove";
            request.Origin = origin;
            var response = _repository.Delete(request);
            _factory.Validator.Validate(response);
            _logger.LogInformation(response.GetMessage());
            return response;
        }

        public BaseResponse Update(BaseRequest request)
        {
            var origin = $"{this.GetType().Name}, Update";
            request.Origin = origin;
            var response = _repository.Update(request);
            _factory.Validator.Validate(response);
            _logger.LogInformation(response.GetMessage());
            return response;
        }

        public BaseResponse Get(BaseRequest request)
        {
            var origin = $"{this.GetType().Name}, Get";
            request.Origin = origin;
            var response = _repository.GetById(request);
            _factory.Validator.Validate(response);
            _logger.LogInformation(response.GetMessage());
            return response;
        }

        public BaseResponse GetMany(BaseRequest request)
        {
            var origin = $"{this.GetType().Name}, GetMany";
            request.Origin = origin;
            var response = _repository.GetById(request);
            _factory.Validator.Validate(response);
            _logger.LogInformation(response.GetMessage());
            return response;
        }

        public BaseResponse GetSorted(BaseRequest request)
        {
            var origin = $"{this.GetType().Name}, GetSorted";
            request.Origin = origin;
            var response = _repository.Sort(request);
            _factory.Validator.Validate(response);
            _logger.LogInformation(response.GetMessage());
            return response;

        }

        public BaseResponse GetFiltered(BaseRequest request)
        {
            var origin = $"{this.GetType().Name}, GetSorted";
            request.Origin = origin;
            var response = _repository.Sort(request);
            _factory.Validator.Validate(response);
            _logger.LogInformation(response.GetMessage());
            return response;
        }
    }
}
