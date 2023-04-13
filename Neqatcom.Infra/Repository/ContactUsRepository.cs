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
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly IDbContext _dbContext;
        public ContactUsRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void CreateContactUs(Gpcontactu contact)
        {
            var p = new DynamicParameters();
            p.Add("FName", contact.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LName", contact.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Email_", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PhoneNumber_", contact.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("message_", contact.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("GP_ContactUs_PACKAGE.InsertContactUs", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteContactUs(int id)
        {
            var p = new DynamicParameters();
            p.Add("ContactUsID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("GP_ContactUs_PACKAGE.DeleteContactUs", p, commandType: CommandType.StoredProcedure);
        }

        public List<Gpcontactu> GetAllContactUs()
        {
            IEnumerable<Gpcontactu> result = _dbContext.Connection.Query<Gpcontactu>("GP_ContactUs_PACKAGE.GetAllContactUs",
               commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Gpcontactu GetContactUsByID(int id)
        {
             var p = new DynamicParameters();
            p.Add("id_", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Gpcontactu> result = _dbContext.Connection.Query<Gpcontactu>("GP_ContactUs_PACKAGE.GetContactUsByID",
                p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void UpdateContactUs(Gpcontactu contact)
        {
            var p = new DynamicParameters();
            p.Add("id_", contact.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("FName", contact.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LName", contact.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Email_", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PhoneNumber_", contact.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("message_", contact.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("GP_ContactUs_PACKAGE.UpdateContactUs", p, commandType: CommandType.StoredProcedure);
        }
    }
}
