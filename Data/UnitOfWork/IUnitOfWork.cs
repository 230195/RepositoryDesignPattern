using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        int Commit();
    }
}
