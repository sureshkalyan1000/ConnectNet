namespace ConnectNet.Errors
{
    public class ApiException
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public string details { get; set; }

        public ApiException(int statusCode, string message, string details)
        {
            this.statusCode = statusCode;
            this.message = message;
            this.details = details;
        }
    }
}
