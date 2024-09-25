    using FluentValidation.Results;

namespace ESCMB.Application.Exceptions
{
    /// <summary>
    /// Las excepciones custom deben ir definidas aqui
    /// </summary>
    /// 
    public class BussinessException : ApplicationException
    {
        public BussinessException()
        {
        }

        public BussinessException(string message) : base(message)
        {
        }

        public BussinessException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class EntityDoesExistException : ApplicationException
    {
        public EntityDoesExistException() : base(Constants.ENTITY_DOES_EXIST_EXCEPTION)
        {
        }

        public EntityDoesExistException(string message) : base(message)
        {
        }

        public EntityDoesExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class EntityDoesNotExistException : ApplicationException
    {
        public EntityDoesNotExistException() : base(Constants.ENTITY_DOESNOT_EXIST_EXCEPTION)
        {
        }

        public EntityDoesNotExistException(string message) : base(message)
        {
        }

        public EntityDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class InvalidEntityDataException : ApplicationException
    {
        public IList<string> Messages { get; private set; }
        public InvalidEntityDataException(IList<ValidationFailure> failures) : base()
        {
            Messages = (from item in failures select item.ErrorMessage).ToList();
        }

        public InvalidEntityDataException()
        {
        }

        public InvalidEntityDataException(string message) : base(message)
        {
        }

        public InvalidEntityDataException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
