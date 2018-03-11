using GeoZoneReferential.Domain.Entities.Interfaces;
using GeoZoneReferential.Domain.Interfaces;
using GeoZoneReferential.Domain.Shared.Interfaces;
using GeoZoneReferential.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GeoZoneReferential.Domain.Services
{
    /// <summary>
    /// Is used to define the implementation the using of DP Repository through a service class
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class, IEntity
    {
        protected readonly IRepository<TEntity> _repository;

        public EntityService(IRepository<TEntity> repository)
        {
            this._repository = repository;
        }

        public virtual TEntity Create(TEntity obj, bool hasToBeSave = true)
        {
            this._repository.Create(obj);
            if (hasToBeSave)
                this.Save();

            return obj;
        }

        public virtual TEntity Update(TEntity obj, bool hasToBeSave = true)
        {
            this._repository.Update(obj);
            if (hasToBeSave)
                this.Save();

            return obj;
        }

        public virtual void Delete(int id, bool hasToBeSave = true)
        {
            this._repository.Delete(id);
            if (hasToBeSave)
                this.Save();

            this.Save();
        }

        public virtual void Save()
        {
            this._repository.Save();
        }

        public virtual TEntity GetByID(int id)
        {
            return this._repository.GetByID(id);
        }

        public virtual IReadOnlyList<TEntity> Search(Expression<Func<TEntity, bool>> expression)
        {
            return this._repository.Research(expression); 
        }

        public virtual TEntity FindOne(Specification<TEntity> specification)
        {
            return this._repository.Find(specification).FirstOrDefault();
        }

        public virtual IReadOnlyList<TEntity> FindList(Specification<TEntity> specification)
        {
            return this._repository.Find(specification).ToList();
        }

        public IReadOnlyList<TEntity> FindListByParentId(int id)
        {
            return this._repository.FindListByParentId(id);
        }

        public TEntity FindOneByParentId(int id)
        {
            return this._repository.FindListByParentId(id).FirstOrDefault();
        }
    }
}