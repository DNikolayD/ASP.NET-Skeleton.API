namespace ASP.NET_Skeleton.Data.Responses
{
    public class BaseDataResponse
    {
        public DateTime CreatedOn { get; set; }

        public string Origin { get; set; } = default!;

        public bool IsSuccessful { get; set; }

        public List<string> Errors { get; set; }

        public object Payload { get; set; } = default!;

        public BaseDataResponse()
        {
            CreatedOn = DateTime.UtcNow;
            Errors = new List<string>();
            IsSuccessful = !Errors.Any();
        }
    }
}
