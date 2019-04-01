using Data.EntityFramework;
using Data.Interfaces;
using Data.Repository;
using System;

namespace Data.UnitOfWork
{
    /// <summary>
    /// This Class receives the instance of DbContext, and furthur generates the required repository using factory settings
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        /// <summary>
        /// Private Readonly fields to inject context for UoW
        /// </summary>
        readonly TestDbContext _context;

        bool _disposed = false;

        #endregion

        #region Constructor

        /// <summary>
        /// public Constructor for UoW class
        /// </summary>
        public UnitOfWork(TestDbContext dbContext)
        {
            _context = dbContext;
        }

        #endregion

        #region Factory Intializers

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_context);
        }


        //private IAuthorizationRepository _authorizationRepository;
        //public IAuthorizationRepository AuthorizationRepository
        //{
        //    get
        //    {
        //        return _authorizationRepository ?? (_authorizationRepository = new AuthorizationRepository(_context));
        //    }
        //}

        #endregion

        #region Common Methods UoW

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>The number of objects written to the underlying database.</returns>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateException">Throw when error occurred sending updates to the database.</exception>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateConcurrencyException">Throw when state of row changed in between fetch and update (Concurrency Issues)</exception>
        /// <exception cref="System.Data.Entity.Validation.DbEntityValidationException">Throw when the neccesary conditions fails to match for Db Columns</exception>
        /// <exception cref="System.NotSupportedException">Thrown when tried to accesss the unsupported behaviours</exception>
        /// <exception cref="System.ObjectDisposedException">Thrown when context aready disposed</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when accessing entities in between the context </exception>
        public int Commit()
        {
            int isSaved = 0;
            try
            {
                isSaved = _context.SaveChanges();
                return isSaved;
            }

            catch (Exception e)
            {
                var error = string.Empty;
                return isSaved;
            }
        }

        /// <summary>
        ///  Disposes the context. The underlying System.Data.Entity.Core.Objects.ObjectContext
        ///  is also disposed if it was created is by this context or ownership was passed
        ///  to this context when this context was created.  The connection to the database
        ///  (System.Data.Common.DbConnection object) is also disposed if it was created
        ///  is by this context or ownership was passed to this context when this context
        ///  was created.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }

        #endregion

    }
}
