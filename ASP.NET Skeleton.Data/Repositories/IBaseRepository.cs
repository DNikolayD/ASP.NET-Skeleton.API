using ASP.NET_Skeleton.Data.Factories;
using ASP.NET_Skeleton.Data.Requests;
using ASP.NET_Skeleton.Data.Responses;

namespace ASP.NET_Skeleton.Data.Repositories
{
    public interface IBaseRepository<TClass, TFactory> where TClass : class, TFactory where TFactory : DataEntityFactory<TClass>

    {
    Task<BaseDataResponse> GetAllAsync();

    Task<BaseDataResponse> GetByIdAsync(BaseDataRequest request);

    Task<BaseDataResponse> InsertAsync(BaseDataRequest request);

    BaseDataResponse Update(BaseDataRequest request);

    Task<BaseDataResponse> DeleteAsync(BaseDataRequest request);

    Task<BaseDataResponse> SaveAsync();

    Task<BaseDataResponse> FilterAsync(BaseDataRequest request);
    }
}
