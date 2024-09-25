using Core.Application;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using MediatR;

namespace ESCMB.Application.UseCases.DummyEntity.Commands.DeleteDummyEntity
{
    internal sealed class DeleteDummyEntityHandler(ICommandQueryBus domainBus, IDummyEntityRepository dummyEntityRepository)
        : IRequestCommandHandler<DeleteDummyEntityCommand, Unit>
    {
        private readonly ICommandQueryBus _domainBus = domainBus ?? throw new ArgumentNullException(nameof(domainBus));
        private readonly IDummyEntityRepository _context = dummyEntityRepository ?? throw new ArgumentNullException(nameof(dummyEntityRepository));

        public Task<Unit> Handle(DeleteDummyEntityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _context.Remove(request.DummyIdProperty);

                _domainBus.Publish(new DummyEntityDeleted(request.DummyIdProperty), cancellationToken);

                return Unit.Task;
            }
            catch (Exception ex)
            {
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    }
}
