﻿using GeoZoneReferential.Domain.Entities.Interfaces;
using GeoZoneReferential.Domain.Shared.Interfaces;
using GeoZoneReferential.Domain.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GeoZoneReferential.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Repository class for EF Core abstraction
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EfCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected DbContext Db { get; }
        protected DbSet<TEntity> Table;

        public EfCoreRepository(DbContext dbContext)
        {
            this.Db = dbContext;
            this.Table = Db.Set<TEntity>();
        }

        /// <summary>
        /// Delete the entity with the id passed if it exist
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            TEntity existing = this.GetByID(id);
            if (existing == null)
                return;

            this.Table.Remove(existing);
        }

        /// <summary>
        /// Delete the entity passed
        /// </summary>
        /// <param name="TEntity"></param>
        public void Delete(TEntity TEntity)
        {
            this.Table.Remove(TEntity);
        }

        /// <summary>
        /// Add the entity passed
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(TEntity entity)
        {
            this.Table.Add(entity);
        }

        /// <summary>
        /// Save the current changes within the current context
        /// </summary>
        public void Save()
        {
            this.Db.SaveChanges();
        }

        /// <summary>
        /// Return all the entity
        /// </summary>
        public IReadOnlyList<TEntity> List()
        {
            return this.Table.ToList();
        }

        /// <summary>
        /// Return the entity with the id identificator passed
        /// </summary>
        /// <param name="id"></param>
        public TEntity GetByID(int id)
        {
            return Table.FirstOrDefault(TEntity => TEntity.Id == id);
        }

        /// <summary>
        /// Update the entity passed
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            Table.Attach(entity);
            this.Db.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Search a liste of entity with the according specification
        /// </summary>
        /// <param name="specification"></param>
        public IReadOnlyList<TEntity> Find(Specification<TEntity> specification)
        {
            return this.Table
                            .Where(specification.ToExpression())
                            .ToList();
        }

        /// <summary>
        /// Find the list of an entity identified by its parent id
        /// </summary>
        /// <param name="id"></param>
        public IReadOnlyList<TEntity> FindListByParentId(int id)
        {
            return this.Table
                            .Where(TEntity => TEntity.ParentId == id)
                            .ToList();
        }
    }
}