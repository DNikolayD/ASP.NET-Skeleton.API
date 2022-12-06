namespace ASP.NET_Skeleton.Common
{
    public static class MessageProvider
    {
        public static string GetMessage(this BaseResponse response)
        {
            var firstPartOfMessage = $"This response was created on {response.CreatedOn.Day} from {BaseResponse.Origin}.";
            var secondPartOfMessage = response.IsSuccessful ? response.GetSuccessMessage() : response.GetErrorMessage();
            var message = string.Concat(firstPartOfMessage, secondPartOfMessage);
            return message;
        }

        private static string GetSuccessMessage(this BaseResponse response)
        {
            return
                $" The response contains no errors and it has payload of type {response.Payload.GetType().Name}";
        }

        private static string GetErrorMessage(this BaseResponse response)
        {
            return
                $" The response contains {response.Errors.Count} errors: {response.Errors.Select(e => e + "\n")}";
        }
    }
}
