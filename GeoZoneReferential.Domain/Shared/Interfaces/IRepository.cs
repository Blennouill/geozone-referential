using GeoZoneReferential.Domain.Entities.Interfaces;
using GeoZoneReferential.Domain.Specifications;
using System.Collections.Generic;

namespace GeoZoneReferential.Domain.Shared.Interfaces
{
    /// <summary>
    /// Interface representing DP Repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IReadOnlyList<TEntity> List();

        TEntity GetByID(int id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);

        void Save();

        IReadOnlyList<TEntity> Find(Specification<TEntity> specification);

        IReadOnlyList<TEntity> FindListByParentId(int id);
    }
}