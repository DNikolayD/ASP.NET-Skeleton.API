namespace ASP.NET_Skeleton.Common
{
    public class BaseResponse : Carrier
    {
        private List<string> _errors;

        public DateTime CreatedOn { get; }

        public static string Origin => default!;

        public bool IsSuccessful { get; private set; }

        public List<string> Errors
        {
            get => _errors;
            set
            {
                IsSuccessful = !value.Any();
                _errors = value;
            }
        }

        public BaseResponse()
        {
            CreatedOn = DateTime.UtcNow;
            Errors = new List<string>();
        }
    }
}
