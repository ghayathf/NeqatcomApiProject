using Dapper;
using Neqatcom.Core.Common;
using Neqatcom.Core.Data;
using Neqatcom.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neqatcom.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext _dbContext;
        public void CreateCategory(Gpcategory gpcategory)
        {
            var p = new DynamicParameters();
            p.Add("cat_name", gpcategory.Categoryname, DbType.String, direction: ParameterDirection.Input);
            p.Add("cat_img", gpcategory.Categoryimage, DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("GP_Category_PACKAGE.CreateCategory", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id_", id, DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("GP_Category_PACKAGE.DeleteCategory", p, commandType: CommandType.StoredProcedure);
        }

        public List<Gpcategory> GetAllCategories()
        {
            IEnumerable<Gpcategory> category = _dbContext.Connection.Query<Gpcategory>("GPLOAN_Package.GetAllLoans"
                , commandType: CommandType.StoredProcedure);
            return category.ToList();

            
        }

        public Gpcategory GetCategoryById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id_", id, DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Gpcategory> gpcategories = _dbContext.Connection.Query<Gpcategory>("GP_Category_PACKAGE.GetCategoryById", p, commandType: CommandType.StoredProcedure);
            return gpcategories.FirstOrDefault();
        }

        public void UpdateCategory(Gpcategory gpcategory)
        {
            var p = new DynamicParameters();
            p.Add("id_", gpcategory.Categoryid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("cat_name", gpcategory.Categoryname, DbType.String, direction: ParameterDirection.Input);
            p.Add("cat_img", gpcategory.Categoryimage, DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("GP_Category_PACKAGE.CreateCategory", p, commandType: CommandType.StoredProcedure);
        }

       
    }
}
