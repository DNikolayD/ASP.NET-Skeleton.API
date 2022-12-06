namespace ASP.NET_Skeleton.Common
{
    public static class AutoMapper
    {
        public static T MapTo<T>(this object entity)
        {
            var result = Activator.CreateInstance<T>();
            result?.GetType().GetProperties().Where(p => p.CanRead && p.CanWrite && p.GetType().IsValueType).ToList().ForEach(p => p.SetValue(p, entity.GetType().GetProperty(p.Name)?.GetValue(entity)));
            result?.GetType().GetProperties().Where(p => p.CanWrite && p.CanRead && p.GetType().IsGenericType).ToList().FindAll(p => p.GetValue(p) != null).ForEach(p =>
            {
                p.SetValue(p, (entity.GetType().GetProperty(p.Name)?.GetValue(entity) as List<object> ?? new List<object>()).Select(e => e.MapTo<T>()));
            });

            return result;
        }
    }
}