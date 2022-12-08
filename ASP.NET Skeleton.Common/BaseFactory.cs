namespace ASP.NET_Skeleton.Common
{
    public abstract class BaseFactory<TClass> where TClass : class
    {
        public virtual BaseValidator Validator { get; set; } = new();

        protected virtual TClass? InitialiseEntity(List<KeyValuePair<string, object>> properties)
        {
            var type = typeof(TClass);
            var result = Activator.CreateInstance(type);
            properties.ForEach(x => result?.GetType().GetProperty(x.Key)?.SetValue(result, x.Value));
            return result as TClass;
        }
    }
}
