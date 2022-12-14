namespace ASP.NET_Skeleton.Common
{
    public abstract class ResponseFactory : BaseFactory<BaseResponse>
    {
        public static BaseResponse InitialiseEntity()
        {
            return Activator.CreateInstance<BaseResponse>();
        }
    }
}
