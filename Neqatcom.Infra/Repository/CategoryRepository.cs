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
        public CategoryRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
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

        public async Task<List<Gpcategory>> GetAllCategories()
        {
            var p = new DynamicParameters();
             var result = await _dbContext.Connection.QueryAsync<Gpcategory, Gpoffer, Gpcategory>("GP_Category_PACKAGE.GetAllCategory", (category, offer) =>
            {
                category.Gpoffers.Add(offer);
                return category;
            },
            splitOn: "offerid"
            ,
            param: null,
            commandType: CommandType.StoredProcedure);

            var results = result.GroupBy(p => p.Categoryid).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.Gpoffers = g.Select(p => p.Gpoffers.Single()).ToList();
                return groupedPost;
            });

            return result.ToList();
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
