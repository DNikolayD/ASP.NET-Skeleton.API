using ASP.NET_Skeleton.Common;
using ASP.NET_Skeleton.Service.InjectionTypes;

namespace ASP.NET_Skeleton.Service
{
    public interface IBaseService : IScopedService
    {
        public Task<BaseResponse> AddAsync(BaseRequest request);

        public Task<BaseResponse> RemoveAsync(BaseRequest request);

        public Task<BaseResponse> UpdateAsync(BaseRequest request);

        public Task<BaseResponse> GetAsync(BaseRequest request);

        public Task<BaseResponse> GetMany(BaseRequest request);

        public Task<BaseResponse> GetSortedAsync(BaseRequest request);

        public Task<BaseResponse> GetFilteredAsync(BaseRequest request);
    }
}
