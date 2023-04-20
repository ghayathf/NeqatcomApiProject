using Dapper;
using Neqatcom.Core.Common;
using Neqatcom.Core.DTO;
using Neqatcom.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Neqatcom.Infra.Repository
{
    public class LoaneeComplaintsRepository:ILoaneeComplaintsRepository
    {
        private readonly IDbContext dbContext;
        public LoaneeComplaintsRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CheckFiveDays()
        {
            dbContext.Connection.Execute("GPADMIN_Package.checkFiveDays",  commandType: CommandType.StoredProcedure);
        }

        public List<LoaneeComplaintsDTO> GetAllCompliants()
        {
            IEnumerable<LoaneeComplaintsDTO> result = dbContext.Connection.Query<LoaneeComplaintsDTO>("GPADMIN_Package.RetreiveCompliantsInfo", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void ManageComplaints(int LID, int CID)
        {
            var p = new DynamicParameters();
            p.Add("LID", LID, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CID", CID, DbType.Int32, direction: ParameterDirection.Input);

            dbContext.Connection.Execute("GPADMIN_Package.ManageLoaneeComplaints", p, commandType: CommandType.StoredProcedure);
        }
    }
}
