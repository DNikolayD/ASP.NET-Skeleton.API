using System.Globalization;

namespace ASP.NET_Skeleton.Common
{
    public static class MessageProvider
    {
        public static string GetMessage(this BaseResponse response)
        {
            var firstPartOfMessage = $"This response was created on {response.CreatedOn.Day} of {CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(response.CreatedOn.Month)} {response.CreatedOn.Year} from {BaseResponse.Origin}.";
            var secondPartOfMessage = response.IsSuccessful ? response.GetSuccessMessage() : response.GetErrorMessage();
            var message = string.Concat(firstPartOfMessage, secondPartOfMessage);
            return message;
        }

        private static string GetSuccessMessage(this Carrier response)
        {
            return
                $" The response contains no errors and it has payload of type {response.Payload.GetType().Name}";
        }

        private static string GetErrorMessage(this BaseResponse response)
        {
            return response.Errors.Count == 1 ? $" The response contains 1 error: {response.Errors.FirstOrDefault()}" : $" The response contains {response.Errors.Count} errors: {response.Errors.Select(e => e + "\n")}";
        }
    }
}
