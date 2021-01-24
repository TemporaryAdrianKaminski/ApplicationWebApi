using Application.DA;
using Application.Models;
using Application.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories.Common
{
    public class ModelsRepository : GenericRepository<Model>, IModelsRepository
    {
        public ModelsRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
