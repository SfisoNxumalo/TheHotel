namespace TheHotel.Application.ServiceCustomExceptions
{
    public  class CustomServiceExceptions
    {
    }

    public class NoContentException : Exception
    {
        public NoContentException(string message) : base(message) { }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }

    public class ServiceException : Exception
    {
        public ServiceException(String message) : base(message) { }
    }
}
