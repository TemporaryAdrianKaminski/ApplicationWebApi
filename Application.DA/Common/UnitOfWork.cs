using Application.DA;
using Application.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DAL.Common
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationContext dbContext;
        private bool disposed = false;

        public UnitOfWork(ApplicationContext context)
        {
            dbContext = context;
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposed)
        {
            if(!disposed)
            {
                if(!isDisposed)
                {
                    dbContext.Dispose();
                }
            }

            disposed = true;
        }
    }
}
