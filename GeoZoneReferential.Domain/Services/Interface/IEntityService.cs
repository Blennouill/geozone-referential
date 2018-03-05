using GeoZoneReferential.Domain.Entities.Interfaces;
using GeoZoneReferential.Domain.Specifications;
using System.Collections.Generic;

namespace GeoZoneReferential.Domain.Interfaces
{
    /// <summary>
    /// Interface of entity service
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IEntityService<TEntity> where TEntity : IEntity
    {
        TEntity GetByID(int id);

        TEntity Create(TEntity obj);

        TEntity Update(TEntity obj);

        void Delete(int id);

        void Save();

        TEntity FindOne(Specification<TEntity> specification);

        IReadOnlyList<TEntity> FindList(Specification<TEntity> specification);

        TEntity FindOneByParentId(int id);

        IReadOnlyList<TEntity> FindListByParentId(int id);
    }
}