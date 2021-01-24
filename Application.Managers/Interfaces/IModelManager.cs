
using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Managers.Interfaces
{
    public interface IModelManager
    {
        Model GetModelById(int id);

        IEnumerable<Model> GetModels();
        long InsertModel(Model model);
        void DeleteModel(Model model);
        Model UpdateModel(Model model);
        

    }
}
