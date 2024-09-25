using Core.Application.Repositories;
using ESCMB.Domain.Entities;

namespace ESCMB.Application.Repositories.Mongo
{
    /// <summary>
    /// Ejemplo de interface de un repositorio Mongo de entidad Dummy
    /// Todo repositorio debe implementar la interfaz <see cref="IMongoDbRepository{TEntity}"/>
    /// donde <c TEntity> es la entidad de dominio que queremos persistir
    /// </summary>
    public interface IDummyEntityRepository : IMongoDbRepository<DummyEntity>
    {
        //Aqui se definen propiedades y metodos Custom.
    }
}
