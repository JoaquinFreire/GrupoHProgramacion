using Core.Application.Repositories;
using ESCMB.Domain.Entities;

namespace ESCMB.Application.Repositories.Sql
{
    /// <summary>
    /// Ejemplo de interface de un repositorio SQL de entidad Dummy
    /// Todo repositorio debe implementar la interfaz <see cref="ISqlRepository{TEntity}"/>
    /// donde <c T> es la entidad de dominio que queremos persistir
    /// </summary>
    public interface IDummyEntityRepository : ISqlRepository<DummyEntity>
    {
        //Aqui se definen propiedades y metodos Custom.
    }
}
