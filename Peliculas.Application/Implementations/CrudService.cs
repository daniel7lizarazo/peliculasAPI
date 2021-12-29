using Peliculas.Application.Interfaces;
using Peliculas.Domain.Entities;
using Peliculas.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peliculas.Application.Implementations
{
    public class CrudService<TEntity,TId> : ICrudService<TEntity,TId>
        where TEntity : Entity<TId>, new()
        where TId : IComparable, IComparable<TId>
    {
        public IRepository<TEntity,TId> _repository { get; set; }
        public CrudService(IRepository<TEntity,TId> repository) => _repository = repository;

        public TEntity Add(TEntity entity)
        {
            entity.Id = GetId();
            return _repository.Add(entity);
        }

        public TEntity Delete(TId id)
        {
            return _repository.Delete(id);
        }

        public List<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(TId id)
        {
            return _repository.GetById(id);
        }

        public List<TEntity> GetByFilter(Func<TEntity, bool> predicate)
        {
            return _repository.GetByFilter(predicate);
        }
        public TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }
        private TId GetId()
        {
            TId id;
            var type = typeof(TId);
            if (type == typeof(Guid))
                id = (TId)(IComparable)Guid.NewGuid();
            else if (type == typeof(string))
                id = (TId)(IComparable)Guid.NewGuid().ToString();
            else
                id = (TId)(IComparable)0;
            return id;
        }
    }
}
