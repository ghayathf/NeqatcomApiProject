using Neqatcom.Core.Data;
using Neqatcom.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Service
{
    public interface IMeetingService
    {
        void CreateMeeting(Gpmeeting meeting);
        void UpdateMeeting(Gpmeeting meeting);
        void DeleteMeeting(int IDD);
        Gpmeeting GetMeetingByID(int IDD);
        List<Gpmeeting> GetAllMeetings();

    }
}
