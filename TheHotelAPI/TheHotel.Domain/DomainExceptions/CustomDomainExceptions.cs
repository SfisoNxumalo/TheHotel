namespace TheHotel.Domain.DomainExceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message)
        {

        }

        
    }

    public class ServiceException : Exception
    {
        public ServiceException(String message) : base(message) { }
    }
}
