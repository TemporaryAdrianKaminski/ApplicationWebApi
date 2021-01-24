using Application.DA;
using Application.DAL.Models;
using Application.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DAL.Common
{
    public class ModelsRepository : GenericRepository<Model>, IModelsRepository
    {
        public ModelsRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
