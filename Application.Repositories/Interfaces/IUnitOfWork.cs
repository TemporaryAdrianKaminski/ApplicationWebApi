﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
