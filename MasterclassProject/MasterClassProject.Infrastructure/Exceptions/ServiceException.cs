namespace MasterClassProject.Infrastructure.Exceptions
{
    public class ServiceException : Exception
    {
        public int StatusCode { get; }

        public ServiceException(string message, int statusCode = 500) : base(message)
        {
            StatusCode = statusCode;
        }

        public ServiceException(long id, int statusCode = 409) : base($"Item with id: {id} already exists!")
        {
            StatusCode = statusCode;
        }

        public ServiceException(int statusCode = 409) : base($"Item already exists!")
        {
            StatusCode = statusCode;
        }
    }
}