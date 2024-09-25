using Core.Application;
using ESCMB.Application.DataTransferObjects;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;

namespace ESCMB.Application.UseCases.DummyEntity.Queries.GetDummyEntityBy
{
    internal sealed class GetDummyEntityByHandler(IDummyEntityRepository context) : IRequestQueryHandler<GetDummyEntityByQuery, DummyEntityDto>
    {
        private readonly IDummyEntityRepository _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<DummyEntityDto> Handle(GetDummyEntityByQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.DummyEntity entity = await _context.FindOneAsync(request.DummyIdProperty) ?? throw new EntityDoesNotExistException();
            return entity.To<DummyEntityDto>();
        }
    }
}
