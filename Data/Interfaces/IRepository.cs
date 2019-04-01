using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Add Entity
        EntityEntry<TEntity> Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        #endregion

        #region Remove Entity

        EntityEntry<TEntity> Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        #endregion

        #region GetRegion
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAllWithFilter(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetListWithIncludeFilter(Expression<Func<TEntity, bool>> predicate,
                                                             params Expression<Func<TEntity, object>>[] includeFilter);
        IEnumerable<TTarget> GetWithProjection<TTarget>(Expression<Func<TEntity, TTarget>> selector);

        IEnumerable<TTarget> GetAllWithProjection<TTarget>(Expression<Func<TEntity, TTarget>> selector, Expression<Func<TEntity, bool>> predicate);
        #endregion

    }
}
