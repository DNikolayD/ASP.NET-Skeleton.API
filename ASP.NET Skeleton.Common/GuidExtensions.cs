namespace ASP.NET_Skeleton.Common
{
    public static class GuidExtensions
    {
        public static TKey InitialiseId<TKey>(this Guid id)
        {
            return id.ToString().MapTo<TKey>();
        }
    }
}
