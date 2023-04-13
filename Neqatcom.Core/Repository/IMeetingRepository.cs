using Neqatcom.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Repository
{
   public interface IMeetingRepository
    {
        void CreateMeeting(Gpmeeting meeting);
        void UpdateMeeting(Gpmeeting meeting);
        void DeleteMeeting(int IDD);
        Gpmeeting GetMeetingByID(int IDD);
        List<Gpmeeting> GetAllMeetings();
    }
}
