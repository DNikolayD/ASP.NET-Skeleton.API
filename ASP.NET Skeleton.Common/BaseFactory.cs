namespace ASP.NET_Skeleton.Common
{
    public class BaseFactory<TClass> where TClass : class
    {
        protected virtual TClass? InitialiseEntity(List<KeyValuePair<string, object>> properties)
        {
            var type = typeof(TClass);
            var result = Activator.CreateInstance(type);
            properties.ForEach(x => result?.GetType().GetProperty(x.Key)?.SetValue(result, x.Value));
            return result as TClass;
        }
    }
}
