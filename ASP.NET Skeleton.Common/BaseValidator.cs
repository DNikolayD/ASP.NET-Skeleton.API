using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Skeleton.Common
{
    public class BaseValidator<TClass> where TClass : class
    {
        public HashSet<string> Errors { get; } = new HashSet<string>();

        public void Validate(object obj)
        {
            typeof(BaseValidator<>).GetMethods().Where(x => x.Name.Contains("SetRule")).ToList().ForEach(x => x.Invoke(this, new []{ obj }));
        }
    }
}
