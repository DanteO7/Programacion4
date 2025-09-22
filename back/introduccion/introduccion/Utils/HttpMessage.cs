namespace introduccion.Utils
{
    public class HttpMessage
    {
        public string Message { get; set; } = string.Empty;
        public HttpMessage(string message)
        {
            Message = message;
        }
    }
}
