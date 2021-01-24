using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
