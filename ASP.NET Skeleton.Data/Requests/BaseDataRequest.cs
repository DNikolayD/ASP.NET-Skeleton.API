namespace ASP.NET_Skeleton.Data.Requests
{
    public class BaseDataRequest
    {
        public string Origin { get; set; } = default!;
        public string Type { get; set; } = default!;
        public object Payload { get; set; } = default!;
    }
}
