namespace ZooApp.WebAPI.Http
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(int statusCode, object? value) =>
            (StatusCode, Value) = (statusCode, value);

        public int StatusCode { get; }

        public object? Value { get; }
    }
}