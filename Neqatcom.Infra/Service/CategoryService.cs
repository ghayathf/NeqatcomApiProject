using Neqatcom.Core.Data;
using Neqatcom.Core.Repository;
using Neqatcom.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neqatcom.Infra.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public void CreateCategory(Gpcategory gpcategory)
        {
            _categoryRepository.CreateCategory(gpcategory);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }

        public List<Gpcategory> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Gpcategory GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        public void UpdateCategory(Gpcategory gpcategory)
        {
            _categoryRepository.UpdateCategory(gpcategory);
        }
    }
}
