using Dapper;
using Neqatcom.Core.Common;
using Neqatcom.Core.Data;
using Neqatcom.Core.DTO;
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
            p.Add("USERID_", gplenderstore.Lenderuserid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("REGISTERSTATUS_", -1, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("SHADOWSTATUS_", 0, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("COMPANTSIZE_", gplenderstore.Companysize, DbType.String, direction: ParameterDirection.Input);
            p.Add("SITEURL_", gplenderstore.Siteurl, DbType.String, direction: ParameterDirection.Input);



            var result = _dbContext.Connection.Execute("GP_LENDERSTORE_PACKAGE.CreateLenderStore", p, commandType: CommandType.StoredProcedure);
        }
        public void giveComplaintForLoanee(Gpcomplaint gpcomplaint)
        {
            var p = new DynamicParameters();
            p.Add("note", gpcomplaint.Compliantnotes, DbType.String, direction: ParameterDirection.Input);
            p.Add("datof", gpcomplaint.Dateofcomplaints, DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("LendId", gpcomplaint.Leid, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("LoaneID", gpcomplaint.Loid, DbType.Decimal, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("GP_LENDERSTORE_PACKAGE.GiveComplaintToLoanee", p, commandType: CommandType.StoredProcedure);

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
        public LenderInfo GetLenderInfo(int id)
        {
            var p = new DynamicParameters();
            p.Add("lendId", id, DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<LenderInfo> gplenderstores = _dbContext.Connection.Query<LenderInfo>("GP_LENDERSTORE_PACKAGE.lenderInfo", p, commandType: CommandType.StoredProcedure);

            return gplenderstores.FirstOrDefault();
        }

        public List<LenderUser> GetAllLenderUser()
        {
            IEnumerable<LenderUser> result = _dbContext.Connection.Query<LenderUser>("GP_LENDERSTORE_PACKAGE.getLenderUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Gplenderstore GetLenderStoreById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id_", id, DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Gplenderstore> gplenderstores = _dbContext.Connection.Query<Gplenderstore>("GP_LENDERSTORE_PACKAGE.GetLenderStoreById", p, commandType: CommandType.StoredProcedure);

            return gplenderstores.FirstOrDefault();
        }
        public List<LoaneesForLendercs> GetAllLoaneesForLendercs(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID_", id, DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<LoaneesForLendercs> gplenderstores = _dbContext.Connection.Query<LoaneesForLendercs>("GP_LENDERSTORE_PACKAGE.LOANEESFORLENDER", p, commandType: CommandType.StoredProcedure);

            return gplenderstores.ToList();
        }
    
        public void UpdateLenderStore(Gplenderstore gplenderstore)
        {
            var p = new DynamicParameters();
            p.Add("ID_", gplenderstore.Lenderid, DbType.Int32, direction: ParameterDirection.Input);

            p.Add("COMMERCIALREGISTER_", gplenderstore.Commercialregister, DbType.String, direction: ParameterDirection.Input);
            p.Add("USERID_", gplenderstore.Lenderuserid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("REGISTERSTATUS_", gplenderstore.Registerstatus, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("SHADOWSTATUS_", gplenderstore.Shadowstatus, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("COMPANTSIZE_", gplenderstore.Companysize, DbType.String, direction: ParameterDirection.Input);
            p.Add("SITEURL_", gplenderstore.Siteurl, DbType.String, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("GP_LENDERSTORE_PACKAGE.updateLenderStore", p, commandType: CommandType.StoredProcedure);
        }

        public List<LoanOffer> GetAllLoanOffer(int lenderid, int loaneeid)
        {
            var p = new DynamicParameters();
            p.Add("LenderIDD", lenderid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("LoaneeIDD", loaneeid, DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<LoanOffer> loanOffers = _dbContext.Connection.Query<LoanOffer>("GP_LENDERSTORE_PACKAGE.LoansForLoanee", p, commandType: CommandType.StoredProcedure);
            return loanOffers.ToList();
        }
    }
}
