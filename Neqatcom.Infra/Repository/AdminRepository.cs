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

        public List<Gpcommercialregister> GetGpcommercialregisters()
        {
            IEnumerable<Gpcommercialregister> loan = dbContext.Connection.Query<Gpcommercialregister>("GPADMIN_Package.GetAllCommercial"
              , commandType: CommandType.StoredProcedure);
            return loan.ToList();
        }

        public void HandleRegistarction(int IDD)
        {
            var p = new DynamicParameters();
            p.Add("IDD", IDD, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Gphomepage> result = dbContext.Connection.Query<Gphomepage>("GPADMIN_Package.HandleRegistration", p, commandType: CommandType.StoredProcedure);
          
        }
    }
}
