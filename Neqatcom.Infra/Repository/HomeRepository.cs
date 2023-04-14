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
    public class HomeRepository : IHomeRepository
    {
        private readonly IDbContext _dbContext;
        public HomeRepository(IDbContext _dbContext)
        {
            this._dbContext = _dbContext;

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

        public void UpdateHomeInformation(Gphomepage finalHomepage)
        {
            var p = new DynamicParameters();
            p.Add("HOME_ID", finalHomepage.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("Home_Logo", finalHomepage.Logo, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PAR1", finalHomepage.Paragraph1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PAR2", finalHomepage.Paragraph2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PAR3", finalHomepage.Paragraph3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ADDRESS", finalHomepage.Companyaddress, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EMAIL", finalHomepage.Companyemail, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PHONE", finalHomepage.Companyphonenumber, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("GP_HOMEPAGE_PACKAGE.UPDATEHOMEINFO", p, commandType: CommandType.StoredProcedure);
        }
    }
}
