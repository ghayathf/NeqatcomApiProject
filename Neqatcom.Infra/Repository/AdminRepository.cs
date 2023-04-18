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
  public  class AdminRepository:IAdminRepository
    {
        private readonly IDbContext dbContext;
        public AdminRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Gpcommercialregister> GetGpcommercialregisters()
        {
            IEnumerable<Gpcommercialregister> loan = dbContext.Connection.Query<Gpcommercialregister>("GPADMIN_Package.GetAllCommercial"
              , commandType: CommandType.StoredProcedure);
            return loan.ToList();
        }
    }
}
