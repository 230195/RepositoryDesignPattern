using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data.EntityFramework;
using Data.Helper;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly TestDataBaseContext _context;
        public DbSet<TEntity> testDBEntity; 

        /// <summary>
        /// Constructor for IRepository Pattern implementation
        /// </summary>
        /// <param name="context">instance of DbContext</param>
        public Repository(TestDataBaseContext context)
        {
            _context = context;
            testDBEntity = _context.Set<TEntity>();
        }

        #region Add Region
        public EntityEntry<TEntity> Add(TEntity entity)
        {
            return _context.Set<TEntity>()
                .Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>()
                .AddRange(entities);
        }
        #endregion

        #region Get Region
        public IEnumerable<TEntity> GetAll()
        {
            return testDBEntity.ToList();
        }

        public TEntity Get(long id)
        {
            return testDBEntity.Find(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return testDBEntity.FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> GetAllWithFilter(Expression<Func<TEntity, bool>> predicate)
        {
            return testDBEntity.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetListWithIncludeFilter(Expression<Func<TEntity, bool>> predicate,
                                                             params Expression<Func<TEntity, object>>[] includeFilter)
        {
            var dbSet = _context.Set<TEntity>().AsQueryable();

            foreach (var child in includeFilter.ToList())
            {
                dbSet = dbSet.Include(child);
            }
            try
            {
                return dbSet.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public IEnumerable<TTarget> GetAllWithProjection<TTarget>(Expression<Func<TEntity, TTarget>> selector, Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TTarget> GetWithProjection<TTarget>(Expression<Func<TEntity, TTarget>> selector)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Remove Region

        public EntityEntry<TEntity> Remove(TEntity entity)
        {
            return testDBEntity.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>()
                .RemoveRange(entities);
        }

        #endregion
    }
}
