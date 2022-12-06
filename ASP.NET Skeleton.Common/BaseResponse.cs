namespace ASP.NET_Skeleton.Common
{
    public class BaseResponse
    {
        public DateTime CreatedOn { get; }

        public static string Origin => default!;

        public bool IsSuccessful { get; }

        public List<string> Errors { get; }

        public object Payload { get; set; } = default!;

        public BaseResponse()
        {
            CreatedOn = DateTime.UtcNow;
            Errors = new List<string>();
            IsSuccessful = !Errors.Any();
        }
    }
}
