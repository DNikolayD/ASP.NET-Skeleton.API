using ASP.NET_Skeleton.Common;

namespace ASP.NET_Skeleton.Data.Repositories
{
    public interface IBaseRepository 
    {
        BaseResponse GetMany(BaseRequest request);

        BaseResponse GetById(BaseRequest request);

        Task<BaseResponse> InsertAsync(BaseRequest request);

        BaseResponse Update(BaseRequest request);

        BaseResponse Delete(BaseRequest request);

        Task<BaseResponse> SaveAsync();

        BaseResponse Filter(BaseRequest request);

        BaseResponse Sort(BaseRequest request);
    }
}
