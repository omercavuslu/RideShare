using RideShare.DataAccess.Repository;
using RideShare.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.DataAccess.UnitOfWork
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbContext;

        public UnitOfWork(DatabaseContext dbContext)
        {
            //Database.SetInitializer<EFBlogContext>(null);

            if (dbContext == null)
                throw new ArgumentNullException("dbContext can not be null.");

            _dbContext = dbContext;
        }

        #region IUnitOfWork Members
        public IRepository<T> GetRepository<T>() where T :  BaseEntity
        {
            return new Repository<T>(_dbContext);
        }

        public int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region IDisposable Members
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
