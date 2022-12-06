
namespace ASP.NET_Skeleton.Common
{
    public class BaseValidator
    {
        public HashSet<string> Errors { get; } = new HashSet<string>();

        public void Validate(object obj)
        {
            typeof(BaseValidator).GetMethods().Where(x => x.Name.Contains("SetRule")).ToList().ForEach(x => x.Invoke(this, new []{ obj }));
        }
    }
}
