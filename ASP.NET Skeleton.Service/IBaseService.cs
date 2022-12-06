using ASP.NET_Skeleton.Common;
using ASP.NET_Skeleton.Service.InjectionTypes;

namespace ASP.NET_Skeleton.Service
{
    public interface IBaseService : IScopedService
    {
        public Task<BaseResponse> AddAsync(BaseRequest request);

        public BaseResponse Remove(BaseRequest request);

        public BaseResponse Update(BaseRequest request);

        public BaseResponse Get(BaseRequest request);

        public BaseResponse GetMany(BaseRequest request);

        public BaseResponse GetSorted(BaseRequest request);

        public BaseResponse GetFiltered(BaseRequest request);
    }
}
