//using Peliculas.Application.Utils;
//using Peliculas.Domain.Entities;
//using Peliculas.Domain.Repository;
//using Peliculas.Infraestructure.Context;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Peliculas.Infraestructure
//{
//    public class EFCoreRepository<TEntity,TId> : IRepository<TEntity,TId> 
//        where TEntity : Entity<TId>, new()
//        where TId : IComparable, IComparable<TId>
//    {
//        private readonly PeliculasContext _context;
//        public EFCoreRepository(PeliculasContext context) => _context = context;

//        public TEntity Add(TEntity entity)
//        {
//            _context.Set<TEntity>().Add(entity);
//            Commit();
//            return entity;
//        }

//        public TEntity Delete(TId id)
//        {
//            var entity = GetById(id);
//            _context.Set<TEntity>().Remove(entity);
//            Commit();
//            return entity;
//        }

//        public List<TEntity> GetAll()
//        {
//            return _context.Set<TEntity>().ToList();
//        }

//        public TEntity GetById(TId id)
//        {
//            return _context.Set<TEntity>().Where(x => x.Id.Equals(id)).FirstOrDefault();
//        }

//        public List<TEntity> GetByFilter(Func<TEntity, bool> predicate)
//        {
//            return _context.Set<TEntity>().Where(predicate).ToList();
//        }
//        public TEntity Update(TEntity entity)
//        {
//            _context.Set<TEntity>().Update(entity);
//            Commit();
//            return entity;
//        }

//        private void Commit()
//        {
//            _context.SaveChanges();
//        }
//    }
//}
