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
    public class PurchasingRepository : IPurchasingRepository
    {
        private readonly IDbContext _dbContext;
        public PurchasingRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void CreatePurchasing(Gppurchasing purchasing)
        {
            var p = new DynamicParameters();
            p.Add("type", purchasing.Paymenttype, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("date", purchasing.Paymentdate, dbType: DbType.DateTime, ParameterDirection.Input);
            p.Add("LID", purchasing.Loanid, dbType: DbType.Int32, ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("GP_Purchasing_Package.CreatePurchasing", p, commandType: CommandType.StoredProcedure);
        }

        public void DeletePurchasing(int id)
        {
            var p = new DynamicParameters();
            p.Add("idd", id, dbType: DbType.Int32, ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("GP_Purchasing_Package.DELETEPurchasing", p, commandType: CommandType.StoredProcedure);
        }

        public List<Gppurchasing> GetAllPurchasing()
        {
            IEnumerable<Gppurchasing> result = _dbContext.Connection.Query<Gppurchasing>("GP_Purchasing_Package.GetAllPurchasing", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Gppurchasing GetPurchasingById(int id)
        {
            var p = new DynamicParameters();
            p.Add("idd", id, dbType: DbType.Int32, ParameterDirection.Input);
            IEnumerable<Gppurchasing> result = _dbContext.Connection.Query<Gppurchasing>("GP_Purchasing_Package.GetPurchasingById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<Gppurchasing> GettAllPayments(int id)
        {
            var p = new DynamicParameters();
            p.Add("LOANIDD", id, dbType: DbType.Int32, ParameterDirection.Input);
            IEnumerable<Gppurchasing> result = _dbContext.Connection.Query<Gppurchasing>("GP_Purchasing_Package.GETALLPAYMENTS", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

            public void UpdatePurchasing(Gppurchasing purchasing)
        {
            var p = new DynamicParameters();
            p.Add("idd", purchasing.Purchaseid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("type", purchasing.Paymenttype, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("date", purchasing.Paymentdate, dbType: DbType.DateTime, ParameterDirection.Input);
            p.Add("LID", purchasing.Loanid, dbType: DbType.Int32, ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("GP_Purchasing_Package.UpdatePurchasing", p, commandType: CommandType.StoredProcedure);
        }
    }
}
