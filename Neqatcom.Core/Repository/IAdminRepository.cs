using Neqatcom.Core.Data;
using Neqatcom.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Repository
{
   public interface IAdminRepository
    {
        List<Gpcommercialregister> GetGpcommercialregisters();
        void HandleRegistarction(int IDD);
        List<LoaneeCreditScores> loaneeCreditScores();
        List<ActorCounterDTO> ActorCounter();
        void deleteComplaint(int cid);
        List<LenderComplaints> GetLenderStoresComplaints();
        void ManageLenderComplaints(int loaid, int CID);
        List<CancleLoanAuto> CancleLoanAutomatically();
        List<CancleLoanMsgforLender> CancleLoanAutoMsgForLender();
    }
}
