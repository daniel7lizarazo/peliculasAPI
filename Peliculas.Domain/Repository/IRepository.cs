using Peliculas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peliculas.Domain.Repository
{
    public interface IRepository<TEntity,TId>
        where TEntity: Entity<TId>, new()
        where TId : IComparable, IComparable<TId>
    {
        public TEntity GetById(TId id);
        public List<TEntity> GetAll();
        public List<TEntity> GetByFilter(Func<TEntity, bool> predicate);
        public TEntity Add(TEntity entity);
        public TEntity Update(TEntity entity);
        public TEntity Delete(TId id);
    }
}
