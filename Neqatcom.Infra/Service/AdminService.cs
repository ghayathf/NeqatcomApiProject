using Neqatcom.Core.Data;
using Neqatcom.Core.DTO;
using Neqatcom.Core.Repository;
using Neqatcom.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Infra.Service
{
   public class AdminService:IAdminService
    {
        private readonly IAdminRepository adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }
        public void deleteComplaint(int cid)
        {
            adminRepository.deleteComplaint(cid);
        }
        public List<ActorCounterDTO> ActorCounter()
        {
            return adminRepository.ActorCounter();
        }

        public List<Gpcommercialregister> GetGpcommercialregisters()
        {
            return adminRepository.GetGpcommercialregisters();
        }

        public List<LenderComplaints> GetLenderStoresComplaints()
        {
            return adminRepository.GetLenderStoresComplaints();
        }

        public void HandleRegistarction(int IDD)
        {
            adminRepository.HandleRegistarction(IDD);
        }

        public List<LoaneeCreditScores> loaneeCreditScores()
        {
            return adminRepository.loaneeCreditScores();
        }

        public void ManageLenderComplaints(int loaid, int CID)
        {
            adminRepository.ManageLenderComplaints(loaid, CID);
        }
    }
}
