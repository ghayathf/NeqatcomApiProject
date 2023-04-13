using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neqatcom.Core.Data;
using Neqatcom.Core.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neqatcom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        [HttpGet]
        [Route("GetAllCategories")]
        public Task<List<Gpcategory>> GetAllCategories()
        {
            return _categoryService.GetAllCategories();
        }
        [HttpGet]
        [Route("GetCategoryById/{id}")]
        public Gpcategory GetCategoryById(int id)
        {
            return _categoryService.GetCategoryById(id);
        }
        [HttpPost]
        [Route("CreateCategory")]
        public void CreateCategory(Gpcategory gpcategory)
        {
            _categoryService.CreateCategory(gpcategory);
        }
        [HttpPut]
        [Route("UpdateCategory")]
        public void UpdateCategory(Gpcategory gpcategory)
        {
            _categoryService.UpdateCategory(gpcategory);
        }
        [HttpDelete]
        [Route("DeleteCategory/{id}")]
       public void DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}
