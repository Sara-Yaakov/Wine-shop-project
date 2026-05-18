
namespace Dal;

public class DalExceptions
{

    public class DalIdNotFoundException : Exception
    {
        public DalIdNotFoundException(string message) : base(message) { }
        public DalIdNotFoundException(string message, Exception innerException) : base(message, innerException) { } 
    }

    public class DalIdAlreadyExistsException : Exception
    {
        public DalIdAlreadyExistsException(string message) : base(message) { }
        public DalIdAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
    }

}

