using GeoZoneReferential.Domain.Entities.Interfaces;
using GeoZoneReferential.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GeoZoneReferential.Domain.Interfaces
{
    /// <summary>
    /// Interface of entity service
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IEntityService<TEntity> where TEntity : IEntity
    {
        TEntity Create(TEntity obj, bool hasToBeSaved = true);

        TEntity Update(TEntity obj, bool hasToBeSaved = true);

        void Delete(int id, bool hasToBeSaved = true);

        void Save();

        TEntity GetByID(int id);

        IReadOnlyList<TEntity> Search(Expression<Func<TEntity, bool>> expression);

        TEntity FindOne(Specification<TEntity> specification);

        IReadOnlyList<TEntity> FindList(Specification<TEntity> specification);

        TEntity FindOneByParentId(int id);

        IReadOnlyList<TEntity> FindListByParentId(int id);
    }
}