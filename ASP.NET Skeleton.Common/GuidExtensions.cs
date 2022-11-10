using static System.Guid;

namespace ASP.NET_Skeleton.Common
{
    public static class GuidExtensions
    {
        public static TKey InitialiseId<TKey>(this Guid id)
        {
            return (id.ToString().MapTo(typeof(TKey)) is TKey
                ? (TKey)NewGuid().ToString().MapTo(typeof(TKey))
                : default)!;
        }
    }
}
