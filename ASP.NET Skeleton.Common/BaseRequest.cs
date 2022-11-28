namespace ASP.NET_Skeleton.Common
{
    public class BaseRequest
    {
        public string Origin { get; set; } = default!;
        public string Type { get; set; } = default!;
        public object Payload { get; set; } = default!;
    }
}
