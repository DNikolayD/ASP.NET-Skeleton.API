using ASP.NET_Skeleton.Common;
using ASP.NET_Skeleton.Data.Entities;

namespace ASP.NET_Skeleton.Data.Extensions
{
    public static class BaseDataEntityExtensions
    {
        public static void Configure<TKey>(this BaseDataEntity<TKey> baseDataEntity)
        {
            if (typeof(TKey) == typeof(string))
            {
                baseDataEntity.Id = new Guid().InitialiseId<TKey>();
            }

            if (baseDataEntity.IsDeletable)
            {
                baseDataEntity.IsDeleted = (bool)(baseDataEntity.IsDeleted?.MapTo(typeof(bool)) ?? false);
                if (baseDataEntity.IsDeleted.Value)
                {
                    baseDataEntity.DeletedOn = DateTime.UtcNow;
                }
            }

            if (baseDataEntity.IsModified)
            {
                baseDataEntity.ModifiedOn = DateTime.UtcNow;
            }
        }
    }
}
