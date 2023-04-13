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
   public class LoanRepository :ILoanRepository
    {
        private readonly IDbContext dbContext;
        public LoanRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateLoan(Gploan loan)
        {
            var p = new DynamicParameters();
            p.Add("TotalMon", loan.Totalmonths, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TotalPri", loan.Totalprice, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("EstimatedPri", loan.Estimatedprice, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("MonAmount", loan.Monthlyamount, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("PreCounter", loan.Predayscounter, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("LateCounter", loan.Latedayscounter, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Startd", loan.Startdate, DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("Endd", loan.Enddate, DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("OfferIDD", loan.Offerid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("LoaneeIDD", loan.Loaneeid, DbType.Int32, direction: ParameterDirection.Input);

            dbContext.Connection.Execute("GPLOAN_Package.CreateLoan", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteLoan(int IDD)
        {
            var p = new DynamicParameters();
            p.Add("IDD", IDD, DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("GPLOAN_Package.DeleteLoan", p, commandType: CommandType.StoredProcedure);
        }

        public List<Gploan> GetAllLoans()
        {
            IEnumerable<Gploan> loan = dbContext.Connection.Query<Gploan>("GPLOAN_Package.GetAllLoans"
                , commandType: CommandType.StoredProcedure);
            return loan.ToList();
        }

        public Gploan GetLoanByID(int IDD)
        {
            var p = new DynamicParameters();
            p.Add("IDD", IDD, DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Gploan> loan = dbContext.Connection.Query<Gploan>("GPLOAN_Package.GetLoanByID", p
                , commandType: CommandType.StoredProcedure);
            return loan.FirstOrDefault();
        }

        public void UpdateLoan(Gploan loan)
        {
            var p = new DynamicParameters();
            p.Add("IDD", loan.Id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TotalMon", loan.Totalmonths, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TotalPri", loan.Totalprice, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("EstimatedPri", loan.Estimatedprice, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("MonAmount", loan.Monthlyamount, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("PreCounter", loan.Predayscounter, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("LateCounter", loan.Latedayscounter, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Startd", loan.Startdate, DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("Endd", loan.Enddate, DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("OfferIDD", loan.Offerid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("LoaneeIDD", loan.Loaneeid, DbType.Int32, direction: ParameterDirection.Input);

            dbContext.Connection.Execute("GPLOAN_Package.UpdateLoan", p, commandType: CommandType.StoredProcedure);
        }
    }
}
