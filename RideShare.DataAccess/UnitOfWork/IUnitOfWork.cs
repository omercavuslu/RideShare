using RideShare.DataAccess.Repository;
using RideShare.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        int SaveChanges();
    }
}
