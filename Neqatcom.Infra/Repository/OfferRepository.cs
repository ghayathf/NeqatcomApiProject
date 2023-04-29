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
    public class OfferRepository : IOfferRepository
    {
        private readonly IDbContext _dbContext;
        public OfferRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void CreateOffer(Gpoffer offer)
        {
            var p = new DynamicParameters();
            p.Add("months", offer.Totalmonths , dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("des", offer.Descriptions, dbType: DbType.String, ParameterDirection.Input);
            p.Add("CID", offer.Categoryid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("LID", offer.Lenderid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("minmonth_", offer.Minmonth, dbType: DbType.Int32, ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("GP_Offer_Package.CreateOffer", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteOffer(int id)
        {
            var p = new DynamicParameters();
            p.Add("idd", id, dbType: DbType.Int32, ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("GP_Offer_Package.DELETEOffer", p, commandType: CommandType.StoredProcedure);
        }

        public List<Gpoffer> GetAllOferById(int id)
        {
            var p = new DynamicParameters();
            p.Add("idd", id, dbType: DbType.Int32, ParameterDirection.Input);
            IEnumerable<Gpoffer> result = _dbContext.Connection.Query<Gpoffer>("GP_Offer_Package.GetAllOfferByLenderId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
           
        }

        public List<Gpoffer> GetAllOffers()
        {
            IEnumerable<Gpoffer> result = _dbContext.Connection.Query<Gpoffer>("GP_Offer_Package.GetAllOffers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Gpoffer GetOfferById(int id)
        {
            var p = new DynamicParameters();
            p.Add("idd", id, dbType: DbType.Int32, ParameterDirection.Input);
            IEnumerable<Gpoffer> result = _dbContext.Connection.Query<Gpoffer>("GP_Offer_Package.GetOfferById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateOffer(Gpoffer offer)
        {
            var p = new DynamicParameters();
            p.Add("idd", offer.Offerid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("months", offer.Totalmonths, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("des", offer.Descriptions, dbType: DbType.String, ParameterDirection.Input);
            p.Add("CID", offer.Categoryid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("LID", offer.Lenderid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("minmonth_", offer.Minmonth, dbType: DbType.Int32, ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("GP_Offer_Package.UpdateOffer", p, commandType: CommandType.StoredProcedure);
        }
    }
}
