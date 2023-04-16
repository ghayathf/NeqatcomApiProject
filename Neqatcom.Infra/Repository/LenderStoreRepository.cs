using Dapper;
using Neqatcom.Core.Common;
using Neqatcom.Core.Data;
using Neqatcom.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Neqatcom.Infra.Repository
{
    public class LenderStoreRepository : ILenderStoreRepository
    {
        private readonly IDbContext _dbContext;

        public LenderStoreRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void createLenderStore(Gplenderstore gplenderstore)
        {
            var p = new DynamicParameters();
            p.Add("COMMERCIALREGISTER_", gplenderstore.Commercialregister, DbType.String, direction: ParameterDirection.Input);
            p.Add("USERID_", gplenderstore.Userid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("REGISTERSTATUS_", gplenderstore.Registerstatus, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("SHADOWSTATUS_", gplenderstore.Shadowstatus, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("COMPANTSIZE_", gplenderstore.Companysize, DbType.String, direction: ParameterDirection.Input);
            p.Add("SITEURL_", gplenderstore.Siteurl, DbType.String, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("GP_LENDERSTORE_PACKAGE.CreateLenderStore", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteLenderStore(int id)
        {
            var p = new DynamicParameters();
            p.Add("id_", id, DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("GP_LENDERSTORE_PACKAGE.DeleteLenderStore", p, commandType: CommandType.StoredProcedure);
        }

        public List<Gplenderstore> GetAllLenderStore()
        {
            IEnumerable<Gplenderstore> result = _dbContext.Connection.Query<Gplenderstore>("GP_LENDERSTORE_PACKAGE.GETALLLENDERSTORE", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Gplenderstore GetLenderStoreById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id_", id, DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Gplenderstore> gplenderstores = _dbContext.Connection.Query<Gplenderstore>("GP_LENDERSTORE_PACKAGE.GetLenderStoreById", p, commandType: CommandType.StoredProcedure);

            return gplenderstores.FirstOrDefault();
        }

        public void UpdateLenderStore(Gplenderstore gplenderstore)
        {
            var p = new DynamicParameters();
            p.Add("ID_", gplenderstore.Lenderid, DbType.Int32, direction: ParameterDirection.Input);

            p.Add("COMMERCIALREGISTER_", gplenderstore.Commercialregister, DbType.String, direction: ParameterDirection.Input);
            p.Add("USERID_", gplenderstore.Userid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("REGISTERSTATUS_", gplenderstore.Registerstatus, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("SHADOWSTATUS_", gplenderstore.Shadowstatus, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("COMPANTSIZE_", gplenderstore.Companysize, DbType.String, direction: ParameterDirection.Input);
            p.Add("SITEURL_", gplenderstore.Siteurl, DbType.String, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("GP_LENDERSTORE_PACKAGE.updateLenderStore", p, commandType: CommandType.StoredProcedure);
        }
    }
}
