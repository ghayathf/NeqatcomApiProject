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
    public class TestimonialRepository:ITestimonialRepository
    {

        private readonly IDbContext _dbContext;
       
        public void CreateHomeTestimonial(Gptestimonial finalTestimonial)
        {
            var p = new DynamicParameters();
            p.Add("msg", finalTestimonial.Message, dbType: DbType.String, ParameterDirection.Input);
            p.Add("status", finalTestimonial.Testimonialstatus, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("USERID", finalTestimonial.Userid, dbType: DbType.Int32, ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("GP_Testimonial_Package.CreateTestimonial", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTestimonial(int id)
        {
            var p = new DynamicParameters();
            p.Add("idd", id, dbType: DbType.Int32, ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("GP_Testimonial_Package.DELETETestimoniaL", p, commandType: CommandType.StoredProcedure);
        }
        

        public List<Gptestimonial> GetAllTestimonial()
        {
            IEnumerable<Gptestimonial> result = _dbContext.Connection.Query<Gptestimonial>("GP_Testimonial_Package.GetAllTestimonials", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Gptestimonial GetTestimonialById(int id)
        {
            var p = new DynamicParameters();
            p.Add("idd", id, dbType: DbType.Int32, ParameterDirection.Input);
            IEnumerable<Gptestimonial> result = _dbContext.Connection.Query<Gptestimonial>("GP_Testimonial_Package.GetTestimonialById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateTestimonial(Gptestimonial finalTestimonial)
        {
            var p = new DynamicParameters();
            p.Add("idd", finalTestimonial.Testimonialid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("msg", finalTestimonial.Message, dbType: DbType.String, ParameterDirection.Input);
            p.Add("status", finalTestimonial.Testimonialstatus, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("USERID", finalTestimonial.Userid, dbType: DbType.Int32, ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("GP_Testimonial_Package.UpdateTestimonial", p, commandType: CommandType.StoredProcedure);
        }

    }
}
