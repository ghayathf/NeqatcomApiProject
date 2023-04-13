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
   public class LoaneeRepository:ILoaneeRepository
    {
        private readonly IDbContext dbContext;
        public LoaneeRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateLoanee(Gploanee loanee)
        {
            var p = new DynamicParameters();
            p.Add("NN", loanee.Nationalnumber, DbType.String, direction: ParameterDirection.Input);
            p.Add("DofBirth", loanee.Dateofbirth, DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("LSalary", loanee.Salary, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("NumOffam", loanee.Numoffamily, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Score", loanee.Creditscore, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("userIDD", loanee.Userid, DbType.Int32, direction: ParameterDirection.Input);

            dbContext.Connection.Execute("GPLOANEE_Package.CreateLoanee", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteLoanee(int IDD)
        {
            var p = new DynamicParameters();
            p.Add("IDD", IDD, DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("GPLOANEE_Package.DeleteLoanee", p, commandType: CommandType.StoredProcedure);
        }

        public List<Gploanee> GetAllLoanees()
        {
            IEnumerable<Gploanee> loanee = dbContext.Connection.Query<Gploanee>("GPLOANEE_Package.GetAllLoanees"
                 , commandType: CommandType.StoredProcedure);
            return loanee.ToList();
        }

        public Gploanee GetLoaneeByID(int IDD)
        {
            var p = new DynamicParameters();
            p.Add("IDD", IDD, DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Gploanee> loanee = dbContext.Connection.Query<Gploanee>("GPLOANEE_Package.GetLoaneeByID", p
                , commandType: CommandType.StoredProcedure);
            return loanee.FirstOrDefault();
        }

        public void UpdateLoanee(Gploanee loanee)
        {
            var p = new DynamicParameters();
            p.Add("IDD", loanee.Id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NN", loanee.Nationalnumber, DbType.String, direction: ParameterDirection.Input);
            p.Add("DofBirth", loanee.Dateofbirth, DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("LSalary", loanee.Salary, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("NumOffam", loanee.Numoffamily, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Score", loanee.Creditscore, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("userIDD", loanee.Userid, DbType.Int32, direction: ParameterDirection.Input);

            dbContext.Connection.Execute("GPLOANEE_Package.UpdateLoanee", p, commandType: CommandType.StoredProcedure);
        }
    }
}
