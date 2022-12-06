namespace ASP.NET_Skeleton.Common
{
    public abstract class BaseResponse
    {
        public DateTime CreatedOn { get; }

        public static string Origin => default!;

        public bool IsSuccessful { get; set; }

        public List<string> Errors { get; }

        public object Payload { get; set; } = default!;

        protected BaseResponse()
        {
            CreatedOn = DateTime.UtcNow;
            Errors = new List<string>();
            IsSuccessful = !Errors.Any();
        }
    }
}
