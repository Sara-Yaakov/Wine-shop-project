
namespace Dal;

public class DalExceptions
{

    public class DalIdNotFaundException:Exception
    {
        public DalIdNotFaundException(string message) : base(message) { }
        public DalIdNotFaundException(string message, Exception innerException) : base(message, innerException) { } // לא צריך לעדכן באינר אקזפשיין שלו את האינר אקזפשיין ולשלוח את עצמו להמשך??
    }

    public class DalIdAlreadyExistsException : Exception
    {
        public DalIdAlreadyExistsException(string message) : base(message) { }
        public DalIdAlreadyExistsException(string message, Exception innerException):base(message, innerException) { }
    }

}

