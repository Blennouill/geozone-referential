using GeoZoneReferential.Domain.Entities.Interfaces;
using GeoZoneReferential.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GeoZoneReferential.Domain.Shared.Interfaces
{
    /// <summary>
    /// Interface representing DP Repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity GetByID(int id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);

        void Save();

        IReadOnlyList<TEntity> Research(Expression<Func<TEntity, bool>> expression);

        IReadOnlyList<TEntity> Find(Specification<TEntity> specification);

        IReadOnlyList<TEntity> FindListByParentId(int id);
    }
}