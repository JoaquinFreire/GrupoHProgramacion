using Core.Application;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using MediatR;

namespace ESCMB.Application.UseCases.DummyEntity.Commands.UpdateDummyEntity
{
    internal sealed class UpdateDummyEntityHandler(ICommandQueryBus domainBus, IDummyEntityRepository dummyEntityRepository) : IRequestCommandHandler<UpdateDummyEntityCommand, Unit>
    {
        private readonly ICommandQueryBus _domainBus = domainBus ?? throw new ArgumentNullException(nameof(domainBus));
        private readonly IDummyEntityRepository _context = dummyEntityRepository ?? throw new ArgumentNullException(nameof(dummyEntityRepository));

        public async Task<Unit> Handle(UpdateDummyEntityCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.DummyEntity entity = await _context.FindOneAsync(request.DummyIdProperty) ?? throw new EntityDoesNotExistException();
            entity.SetDummyPropertyTwo(request.DummyPropertyTwo);
            entity.SetDummyPropertyThree(request.DummyPropertyThree);

            try
            {
                _context.Update(entity);

                await _domainBus.Publish(entity.To<DummyEntityUpdated>(), cancellationToken);

                return await Unit.Task;
            }
            catch (Exception ex)
            {
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    }
}
