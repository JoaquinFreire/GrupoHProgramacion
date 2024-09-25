using FluentValidation;
using FluentValidation.Results;

namespace Core.Domain.Entities
{
    public interface IValidate
    {
        bool IsValid();
        IList<ValidationFailure> GetErrors();
    }

    public abstract class DomainEntity<TEntity, TValidator> : IValidate
        where TEntity : DomainEntity<TEntity, TValidator>
        where TValidator : IValidator<TEntity>, new()
    {
        protected TValidator Validator;
        protected ValidationResult ValidationResult;

        protected DomainEntity()
        {
            Validator = new TValidator();
        }

        protected void Validate()
        {
            ValidationResult = Validator.Validate((TEntity)this);
        }

        public bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        public IList<ValidationFailure> GetErrors()
        {
            Validate();
            return ValidationResult.Errors;
        }
    }
}
