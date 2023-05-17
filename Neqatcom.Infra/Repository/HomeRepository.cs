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
    public class HomeRepository : IHomeRepository
    {
        private readonly IDbContext _dbContext;
        public HomeRepository(IDbContext _dbContext)
        {
            this._dbContext = _dbContext;

        }

        public void CalculateCreditScores()
        {
            var result = _dbContext.Connection.Execute("GP_HOMEPAGE_PACKAGE.CalculatCreditScore", commandType: CommandType.StoredProcedure);

        }

        public void CreateHomeInformation(Gphomepage finalHomepage)
        {
            var p = new DynamicParameters();
            p.Add("Home_Logo", finalHomepage.Logo, dbType: DbType.String, direction:ParameterDirection.Input);
            p.Add("PAR1", finalHomepage.Paragraph1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PAR2", finalHomepage.Paragraph2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PAR3", finalHomepage.Paragraph3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ADDRESS", finalHomepage.Companyaddress, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EMAIL", finalHomepage.Companyemail, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PHONE", finalHomepage.Companyphonenumber, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("GP_HOMEPAGE_PACKAGE.CREATEHOMEINFO", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteHomeInformation(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id_", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("GP_HOMEPAGE_PACKAGE.DeleteHOME", p, commandType: CommandType.StoredProcedure); ;
        }

        public List<Gphomepage> GetAllHomeInformation()
        {
            IEnumerable<Gphomepage> result = _dbContext.Connection.Query<Gphomepage>("GP_HOMEPAGE_PACKAGE.GetAllHomeInfo", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Gphomepage GetHomeInformationById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Gphomepage> result = _dbContext.Connection.Query<Gphomepage>("GP_HOMEPAGE_PACKAGE.GetHomeInfoById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<LoaneeReminder> GetLoaneesInPayDaytoRemind()
        {
            //var p = new DynamicParameters();
            //p.Add("currentDate", CurrentDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<LoaneeReminder> result = _dbContext.Connection.Query<LoaneeReminder>("GP_HOMEPAGE_PACKAGE.InPayDayReminder",  commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<LoaneeReminder> GetLoaneeslatePayDaytoRemind()
        {
            //var p = new DynamicParameters();
            //p.Add("currentDate", CurrentDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<LoaneeReminder> result = _dbContext.Connection.Query<LoaneeReminder>("GP_HOMEPAGE_PACKAGE.LateDayReminder",  commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<LoaneeReminder> GetLoaneestoRemind()
        {
            //var p = new DynamicParameters();
            //p.Add("currentDate", CurrentDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<LoaneeReminder> result = _dbContext.Connection.Query<LoaneeReminder>("GP_HOMEPAGE_PACKAGE.PreDayReminder", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Lengths> getTableLength()
        {
            IEnumerable<Lengths> result = _dbContext.Connection.Query<Lengths>("GP_HOMEPAGE_PACKAGE.getTableLength", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void UpdateBeforeReminder()
        {
            //var p = new DynamicParameters();
            //p.Add("currentDate", CurrentDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("GP_HOMEPAGE_PACKAGE.UpdateBeforeReminder", commandType: CommandType.StoredProcedure); 
        }

        public void UpdateHomeInformation(Gphomepage finalHomepage)
        {
            var p = new DynamicParameters();
            p.Add("HOME_ID", finalHomepage.Homeid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("Home_Logo", finalHomepage.Logo, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PAR1", finalHomepage.Paragraph1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PAR2", finalHomepage.Paragraph2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PAR3", finalHomepage.Paragraph3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ADDRESS", finalHomepage.Companyaddress, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EMAIL", finalHomepage.Companyemail, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PHONE", finalHomepage.Companyphonenumber, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("GP_HOMEPAGE_PACKAGE.UPDATEHOMEINFO", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateInPayDateReminder()
        {
            //var p = new DynamicParameters();
            //p.Add("currentDate", CurrentDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("GP_HOMEPAGE_PACKAGE.UpdateInPayDateReminder",  commandType: CommandType.StoredProcedure); ;
        }

        public void UpdateLatePayDateReminder()
        {
            //var p = new DynamicParameters();
            //p.Add("currentDate", CurrentDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("GP_HOMEPAGE_PACKAGE.UpdateLatePayDateReminder",  commandType: CommandType.StoredProcedure); ;
        }
    }
}
