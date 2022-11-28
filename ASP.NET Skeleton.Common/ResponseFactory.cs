namespace ASP.NET_Skeleton.Common
{
    public class ResponseFactory : BaseFactory<BaseResponse>
    {
        public BaseResponse? InitialiseEntity(string origin)
        {
            var properties = new List<KeyValuePair<string, object>>
            {
                new("Origin", origin)
            };
            return base.InitialiseEntity(properties);
        }
    }
}
