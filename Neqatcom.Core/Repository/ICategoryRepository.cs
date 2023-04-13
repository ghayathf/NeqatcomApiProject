using Neqatcom.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neqatcom.Core.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Gpcategory>> GetAllCategories();
        Gpcategory GetCategoryById(int id);
        void CreateCategory(Gpcategory gpcategory);
        void UpdateCategory(Gpcategory gpcategory);
        void DeleteCategory(int id);
    }
}
