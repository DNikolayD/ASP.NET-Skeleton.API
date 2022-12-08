using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Skeleton.Common
{
    public class ResponseFactory : BaseFactory<BaseResponse>
    {
        public BaseResponse InitialiseEntity()
        {
            return Activator.CreateInstance<BaseResponse>();
        }
    }
}
