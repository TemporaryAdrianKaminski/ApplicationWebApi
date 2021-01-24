using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Managers.Interfaces;
using Application.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IModelManager modelsManager;

        public ModelsController(IModelManager modelsManager)
        {
            this.modelsManager = modelsManager;
        }

        [HttpGet("{id}")]
        public Model GetModelById(int id)
        {
            return modelsManager.GetModelById(id);
        }

        [HttpGet]
        public IEnumerable<Model> GetModels()
        {
            return modelsManager.GetModels();
        }

        [HttpPost]
        public long InsertModel([FromBody]Model model)
        {
            return modelsManager.InsertModel(model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateModel(int id, [FromBody]Model modelUpdate)
        {
            var model = modelsManager.GetModelById(id);
            if (model != null)
            {
                model.Title = modelUpdate.Title;
                model.Description = modelUpdate.Description;
                model.IsCompleted = modelUpdate.IsCompleted;
                modelsManager.UpdateModel(model);
            }

            return RedirectToAction("GetModels");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var model = modelsManager.GetModelById(id);
            modelsManager.DeleteModel(model);
            return RedirectToAction("GetModels");
        }



    }
}