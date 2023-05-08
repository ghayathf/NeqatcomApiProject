﻿using Dapper;
using Neqatcom.Core.Common;
using Neqatcom.Core.Data;
using Neqatcom.Core.DTO;
using Neqatcom.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public void ConfirmNewLoanInfo(Gploan loan)
        {
            var p = new DynamicParameters();
            p.Add("LoanIDD", loan.Loanid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TotalMon", loan.Totalmonths, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("TotalPri", loan.Totalprice, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("MonAmount", loan.Monthlyamount, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Startd", loan.Startdate, DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("Endd", loan.Enddate, DbType.DateTime, direction: ParameterDirection.Input);

            dbContext.Connection.Execute("GPLOAN_Package.ConfirmNewLoanInfo", p, commandType: CommandType.StoredProcedure);
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

        public int ExistingLoanCounter(int LoaneeID)
        {
            var p = new DynamicParameters();
            p.Add("inLoaneeId", LoaneeID, DbType.Int32, direction: ParameterDirection.Input);
            var loanCount = dbContext.Connection.QueryFirstOrDefault<int>(
                "GPLOAN_Package.getLoanCountForLoaneeId", p, commandType: CommandType.StoredProcedure);
            return loanCount;
        }


        public List<Gploan> GetAllLoans()
        {
            IEnumerable<Gploan> loan = dbContext.Connection.Query<Gploan>("GPLOAN_Package.GetAllLoans"
                , commandType: CommandType.StoredProcedure);
            return loan.ToList();
        }

        public List<RequestedLoan> GetAllRequestedLoan(int LSID, int statuss)
        {
            var p = new DynamicParameters();
            p.Add("LSID", LSID, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("statuss", statuss, DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<RequestedLoan> loan = dbContext.Connection.Query<RequestedLoan>("GPLOAN_Package.GetRequestedLoansByLS",p
                , commandType: CommandType.StoredProcedure);
            return loan.ToList();
        }

        public List<RequestedLoan> GetAllRequestedPostPone(int LSID, int statuss)
        {
            var p = new DynamicParameters();
            p.Add("LSID", LSID, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("statuss", statuss, DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<RequestedLoan> loan = dbContext.Connection.Query<RequestedLoan>("GPLOAN_Package.GetRequestedPostponeByLS", p
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

        public void RequestNewLoan(int loaneeid, int offerid, int totalmonths)
        {
            var p = new DynamicParameters();
            p.Add("loaneeidd", loaneeid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("offeridd", offerid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("totalmonths_", totalmonths, DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("GPLOAN_Package.RequestNewLoan",p,commandType:CommandType.StoredProcedure);
            
        }

        public void UpdateLoan(Gploan loan)
        {
            var p = new DynamicParameters();
            p.Add("IDD", loan.Loanid, DbType.Int32, direction: ParameterDirection.Input);
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

        public void UpdateLoanStatus(int LoanID, int status)
        {
            var p = new DynamicParameters();
            p.Add("IDD", LoanID, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("newStatus", status, DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("GPLOAN_Package.updateLoanStatus", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdatePostponeStatus(int LoanID, int status, int loaneeidd)
        {
            var p = new DynamicParameters();
            p.Add("IDD", LoanID, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("newStatus", status, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("loaneeidd", loaneeidd, DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("GPLOAN_Package.updatePostponeStatus", p, commandType: CommandType.StoredProcedure);
        }
    }
}
