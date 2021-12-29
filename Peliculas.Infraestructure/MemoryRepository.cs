using Peliculas.Domain.Entities;
using Peliculas.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peliculas.Infraestructure
{
    public class MemoryRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>, new()
        where TId : IComparable, IComparable<TId>
    {
        private static List<TEntity> _List = new List<TEntity>();

        public TEntity Add(TEntity entity)
        {
            _List.Add(entity);
            return entity;
        }

        public TEntity Delete(TId id)
        {
            var entity = GetById(id);
            _List.Remove(entity);
            return entity;
        }

        public List<TEntity> GetAll()
        {
            return _List;
        }

        public TEntity GetById(TId id)
        {
            return _List.Find(x => x.Id.Equals(id));
        }

        public TEntity Update(TEntity entity)
        {
            Delete(entity.Id);
            return Add(entity);
        }

        public List<TEntity> GetByFilter(Func<TEntity, bool> predicate)
        {
            return _List.Where(predicate).ToList();
        }
    }
}
