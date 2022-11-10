using ASP.NET_Skeleton.Common;

namespace ASP.NET_Skeleton.Data.Factories
{
    public class DataEntityFactory<TClass> : BaseFactory<TClass> where TClass : class 
    {
        public BaseValidator<TClass> Validator { get; } = new BaseValidator<TClass>();

        public void Validate(TClass entity)
        {
            Validator.Validate(entity);
        }
    }
}
