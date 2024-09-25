using Core.Application;
using ESCMB.Application.ApplicationServices;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;

namespace ESCMB.Application.UseCases.DummyEntity.Commands.CreateDummyEntity
{
    /// <summary>
    /// Ejemplo de handler que responde al comando <see cref="CreateDummyEntityCommand"/>
    /// y ejecuta el proceso para el caso de uso en cuestion.
    /// Todo handler debe implementar la interfaz <see cref="IRequestCommandHandler{TRequest, TResponse}"/>
    /// si devuelve una respuesta donde <c TRequest> es del tipo <see cref="CreateDummyEntityCommand"/>
    /// y <c TResponse> del tipo de dato definido para la respuesta
    /// /// </summary>
    internal sealed class CreateDummyEntityHandler(ICommandQueryBus domainBus, IDummyEntityRepository dummyEntityRepository, IDummyEntityApplicationService dummyEntityApplicationService) : IRequestCommandHandler<CreateDummyEntityCommand, string>
    {
        private readonly ICommandQueryBus _domainBus = domainBus ?? throw new ArgumentNullException(nameof(domainBus));
        private readonly IDummyEntityRepository _context = dummyEntityRepository ?? throw new ArgumentNullException(nameof(dummyEntityRepository));
        private readonly IDummyEntityApplicationService _dummyEntityApplicationService = dummyEntityApplicationService ?? throw new ArgumentNullException(nameof(dummyEntityApplicationService));
        public async Task<string> Handle(CreateDummyEntityCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.DummyEntity entity = new(request.DummyPropertyTwo, request.DummyPropertyThree);

            if (!entity.IsValid()) throw new InvalidEntityDataException(entity.GetErrors());

            if (_dummyEntityApplicationService.DummyEntityExist(entity.Id)) throw new EntityDoesExistException();

            try
            {
                string createdId = await _context.AddOneAsync(entity);

                await _domainBus.Publish(entity.To<DummyEntityCreated>(), cancellationToken);

                return createdId;
            }
            catch (Exception ex)
            {
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    }
}
