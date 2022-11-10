using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Skeleton.Common
{
    public class BaseFactory<TClass> where TClass : class
    {
        public TClass? InitialiseEntity(List<KeyValuePair<string, object>> properties)
        {
            var type = typeof(TClass);
            var result = Activator.CreateInstance(type);
            properties.ForEach(x => result?.GetType().GetProperty(x.Key)?.SetValue(result, x.Value));
            return result as TClass;
        }
    }
}
