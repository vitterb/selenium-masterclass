namespace MasterCLassProject.Domain.Exceptions
{
    public class StopBeforeStartException : Exception
    {
        public int StatusCode { get; }

        public StopBeforeStartException(string message, int statusCode = 409) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}