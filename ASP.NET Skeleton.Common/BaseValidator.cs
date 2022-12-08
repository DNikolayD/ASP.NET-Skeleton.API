using System.ComponentModel;
using System.Reflection;

namespace ASP.NET_Skeleton.Common
{
    public class BaseValidator
    {
        public HashSet<string> Errors { get; private set; } = new HashSet<string>();

        public bool HasErrors { get; protected set; }


        public virtual void Validate(object obj)
        {
            var validators = Assembly.GetAssembly(typeof(BaseValidator))!
                .GetTypes()
                .Where(myType => myType is {IsClass: true} && myType.IsSubclassOf(typeof(BaseValidator)))
                .Select(type => (BaseValidator) Activator.CreateInstance(type)!)
                .Select(dummy => dummy)
                .ToList(); 
            validators.Sort();
            foreach (var type in validators.Select(validator => validator.GetType()))
            {
                type.GetMethods().Where(x => x.Name.Contains("SetRule")).ToList().ForEach(x => x.Invoke(this, new[] { obj }));
            }

            HasErrors = Errors.Any();
        }

    }
}
