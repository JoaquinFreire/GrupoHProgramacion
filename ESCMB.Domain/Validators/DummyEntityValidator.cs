using Core.Domain.Validators;
using ESCMB.Domain.Entities;
using FluentValidation;

namespace ESCMB.Domain.Validators
{
    /// <summary>
    /// Ejemplo de validador de entidad Dummy
    /// Todo validador de entidad de dominio debe heredar de <see cref="EntityValidator{TEntity}"/>
    /// Donde TEntity es del tipo <see cref="Core.Domain.Entities.DomainEntity{TEntity, TValidator}"/>
    /// </summary>
    public class DummyEntityValidator : EntityValidator<DummyEntity>
    {
        public DummyEntityValidator() //le tengo que avisar a la hermana del Bruno para ver si me deja salir
        {
            //Las reglas de negocio deben ir definidas aca
            RuleFor(x => x.DummyPropertyTwo).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
        }
    }
}
