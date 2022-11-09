using ASP.NET_Skeleton.Data.Requests;
using ASP.NET_Skeleton.Data.Responses;

namespace ASP.NET_Skeleton.Data.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<BaseDataResponse> GetAllAsync();

        Task<BaseDataResponse> GetByIdAsync(BaseDataRequest request);

        Task<BaseDataResponse> InsertAsync(BaseDataRequest request);

        Task<BaseDataResponse> UpdateAsync(BaseDataRequest request);

        Task<BaseDataResponse> DeleteAsync(BaseDataRequest request);

        Task<BaseDataResponse> SaveAsync();

        Task<BaseDataResponse> FilterAsync(BaseDataRequest request);
}
