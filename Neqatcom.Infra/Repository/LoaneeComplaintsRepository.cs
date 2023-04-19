using Dapper;
using Neqatcom.Core.Common;
using Neqatcom.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void ManageComplaints(int LID)
        {
            var p = new DynamicParameters();
            p.Add("LID", LID, DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("GPADMIN_Package.ManageLoaneeComplaints", p, commandType: CommandType.StoredProcedure);
        }
    }
}
