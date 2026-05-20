
namespace BO;

public class BlException : Exception
{
    [Serializable]
    public class BlIdNotExistsException : Exception
    {
        public BlIdNotExistsException(string message) : base(message) { }

        public BlIdNotExistsException(string message, Exception innerExcepion) : base(message, innerExcepion) { }

    }

    [Serializable]
    public class BlIdAlreadyExistsException : Exception
    {
        public BlIdAlreadyExistsException(string message) : base(message) { }

        public BlIdAlreadyExistsException(string message, Exception innerExcepion) : base(message, innerExcepion) { }

    }
    [Serializable]
    public class BlConigException : Exception
    {
        public BlConigException(string message) : base(message) { }

        public BlConigException(string message, Exception innerExcepion) : base(message, innerExcepion) { }

    }
    [Serializable]
    public class BlNoProductInStock : Exception
    {
        public BlNoProductInStock(string message) : base(message) { }

        public BlNoProductInStock(string message, Exception innerExcepion) : base(message, innerExcepion) { }

    }
    [Serializable]
    public class BlNegetiveAmountInOrder : Exception
    {
        public BlNegetiveAmountInOrder(string message) : base(message) { }

        public BlNegetiveAmountInOrder(string message, Exception innerExcepion) : base(message, innerExcepion) { }

    }

}


