using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Skeleton.Data.Entities;

namespace ASP.NET_Skeleton.Data.Factories
{
    public class DataEntityFactory<TClass> where TClass : class
    {
        public TClass? InitialiseEntity(Dictionary<string, object> properties)
        {
            var type = typeof(TClass);
            var result = Activator.CreateInstance(type);
            foreach (var property in properties)
            {
                result?.GetType().GetProperty(property.Key)?.SetValue(result, property.Value);
            }

            return result as TClass;
        }
    }
}
