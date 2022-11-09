namespace ASP.NET_Skeleton.Data.Requests
{
    public class BaseDataRequest
    {
        public string Origin { get; set; }
        public string Type { get; set; }
        public object Payload { get; set; }
    }
}
