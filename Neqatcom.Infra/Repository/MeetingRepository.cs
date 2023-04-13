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
   public class MeetingRepository:IMeetingRepository
    {
        private readonly IDbContext dbContext;
        public MeetingRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateMeeting(Gpmeeting meeting)
        {
            var p = new DynamicParameters();
            p.Add("MeetingDate", meeting.Startdate, DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("Meeting_Url", meeting.Meetingurl, DbType.String, direction: ParameterDirection.Input);
            p.Add("feed_back", meeting.Feedbackk, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("LoaneeIDD", meeting.Loaneeid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("LenderIDD", meeting.Lenderid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Meeting_Time", meeting.Meetingtime, DbType.Int32, direction: ParameterDirection.Input);

            dbContext.Connection.Execute("GPMEETINGS_Package.CreateMeeting", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteMeeting(int IDD)
        {
            var p = new DynamicParameters();
            p.Add("IDD", IDD, DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.Execute("GPMEETINGS_Package.DeleteMeeting", p, commandType: CommandType.StoredProcedure);
        }

        public List<Gpmeeting> GetAllMeetings()
        {
            IEnumerable<Gpmeeting> meeting = dbContext.Connection.Query<Gpmeeting>("GPMEETINGS_Package.GetAllMeetings"
                 , commandType: CommandType.StoredProcedure);
            return meeting.ToList();
        }

        public Gpmeeting GetMeetingByID(int IDD)
        {
            var p = new DynamicParameters();
            p.Add("IDD", IDD, DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Gpmeeting> meeting = dbContext.Connection.Query<Gpmeeting>("GPMEETINGS_Package.GetMeetingByID", p
                , commandType: CommandType.StoredProcedure);
            return meeting.FirstOrDefault();
        }

        public void UpdateMeeting(Gpmeeting meeting)
        {
            var p = new DynamicParameters();
            p.Add("IDD", meeting.Id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MeetingDate", meeting.Startdate, DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("Meeting_Url", meeting.Meetingurl, DbType.String, direction: ParameterDirection.Input);
            p.Add("feed_back", meeting.Feedbackk, DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("LoaneeIDD", meeting.Loaneeid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("LenderIDD", meeting.Lenderid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Meeting_Time", meeting.Meetingtime, DbType.Int32, direction: ParameterDirection.Input);

            dbContext.Connection.Execute("GPMEETINGS_Package.UpdateMeeting", p, commandType: CommandType.StoredProcedure);
        }
    }
}
