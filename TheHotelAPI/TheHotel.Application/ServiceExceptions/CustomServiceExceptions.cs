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

    public class DuplicateRecordException : Exception
    {
        public DuplicateRecordException(string message) : base(message) { }
    }

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message) { }
    }
    public class RealTimeNotificationException : Exception
    {
        public RealTimeNotificationException(string message) : base(message) { }
    }

    public class NoOrderFoundException : Exception
    {
        public NoOrderFoundException(string message) : base(message) { }
    }

    public class IncorrectPassword : Exception
    {
        public IncorrectPassword(string message) : base(message) { }
    }

    public class InappropriateContentException : Exception
    {
        public InappropriateContentException(string message) : base(message) { }
    }
}
