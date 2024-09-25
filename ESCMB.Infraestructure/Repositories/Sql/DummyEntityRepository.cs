using Core.Infraestructure.Repositories.Sql;
using ESCMB.Application.Repositories.Sql;
using ESCMB.Domain.Entities;

namespace ESCMB.Infraestructure.Repositories.Sql
{
    /// <summary>
    /// Ejemplo de repositorio SQL de entidad Dummy
    /// Todo repositorio debe implementar la interfaz que hereda de <see cref="Core.Application.Repositories.ISqlRepository{TEntity}"/>
    /// creada en la capa de aplicacion, y heredar de <see cref="BaseRepository{TEntity}"/>
    /// donde <c TEntity> es la entidad de dominio que queremos persistir
    /// </summary>
    internal sealed class DummyEntityRepository(StoreDbContext context) : BaseRepository<DummyEntity>(context), IDummyEntityRepository
    {
    }
}
