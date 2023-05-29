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
  public  class AdminRepository:IAdminRepository
    {
        private readonly IDbContext dbContext;
        public AdminRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ActorCounterDTO> ActorCounter()
        {
            IEnumerable<ActorCounterDTO> loan = dbContext.Connection.Query<ActorCounterDTO>("GPADMIN_Package.ActorCounter"
              , commandType: CommandType.StoredProcedure);
            return loan.ToList();
        }

        public List<CancleLoanAuto> CancleLoanAutomatically()
        {
            IEnumerable<CancleLoanAuto> loan = dbContext.Connection.Query<CancleLoanAuto>("GP_HOMEPAGE_PACKAGE.CancleLoanAutomatically"
               , commandType: CommandType.StoredProcedure);
            return loan.ToList();
        }

        public List<CancleLoanMsgforLender> CancleLoanAutoMsgForLender()
        {
            IEnumerable<CancleLoanMsgforLender> loan = dbContext.Connection.Query<CancleLoanMsgforLender>("GP_HOMEPAGE_PACKAGE.CancleLoanAutoMsgForLender"
               , commandType: CommandType.StoredProcedure);
            return loan.ToList();
        }

        public void deleteComplaint(int cid)
        {
            var p = new DynamicParameters();
            p.Add("CID", cid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("GPADMIN_Package.DeleteComplaint", p, commandType: CommandType.StoredProcedure);
        }
        public List<Gpcommercialregister> GetGpcommercialregisters()
        {
            IEnumerable<Gpcommercialregister> loan = dbContext.Connection.Query<Gpcommercialregister>("GPADMIN_Package.GetAllCommercial"
              , commandType: CommandType.StoredProcedure);
            return loan.ToList();
        }

        public List<LenderComplaints> GetLenderStoresComplaints()
        {
            IEnumerable<LenderComplaints> loan = dbContext.Connection.Query<LenderComplaints>("GPADMIN_Package.RetreiveLenderCompliantsInfo"
             , commandType: CommandType.StoredProcedure);
            return loan.ToList();
        }

        public void HandleRegistarction(int IDD)
        {
            var p = new DynamicParameters();
            p.Add("IDD", IDD, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("GPADMIN_Package.HandleRegistration", p, commandType: CommandType.StoredProcedure);
          
        }

        public List<LoaneeCreditScores> loaneeCreditScores()
        {
            IEnumerable<LoaneeCreditScores> loan = dbContext.Connection.Query<LoaneeCreditScores>("GPADMIN_Package.CreditScoreCharts"
              , commandType: CommandType.StoredProcedure);
            return loan.ToList();
        }
        public CategoriesStatistics categoriesStatistics()
        {
            IEnumerable<CategoriesStatistics> loan = dbContext.Connection.Query<CategoriesStatistics>("GPADMIN_Package.GetStatistics"
              , commandType: CommandType.StoredProcedure);
            return loan.FirstOrDefault();
        }
        public ComplaintsStatistics complaintsStatistics()
        {
            IEnumerable<ComplaintsStatistics> loan = dbContext.Connection.Query<ComplaintsStatistics>("GPADMIN_Package.GetComplaintStatistics"
              , commandType: CommandType.StoredProcedure);
            return loan.FirstOrDefault();
        }
        public AdminStatisticsLoanee AdminStatisticsLoanee()
        {
            IEnumerable<AdminStatisticsLoanee> loan = dbContext.Connection.Query<AdminStatisticsLoanee>("GPADMIN_Package.GetLoanStatistics"
              , commandType: CommandType.StoredProcedure);
            return loan.FirstOrDefault();
        }
        public LenderAdminStatistics lenderAdminStatistics()
        {
            IEnumerable<LenderAdminStatistics> loan = dbContext.Connection.Query<LenderAdminStatistics>("GPADMIN_Package.GetLenderStats"
              , commandType: CommandType.StoredProcedure);
            return loan.FirstOrDefault();
        }
        public void ManageLenderComplaints(int loaid, int CID)
        {
            var p = new DynamicParameters();
            p.Add("LoaID", loaid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CID", CID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("GPADMIN_Package.ManageLenderComplaints", p, commandType: CommandType.StoredProcedure);
        }
       
    }
}
