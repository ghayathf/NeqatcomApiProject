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

        public List<ActorCounterDTO> ActorCounter()
        {
            return adminRepository.ActorCounter();
        }

        public List<Gpcommercialregister> GetGpcommercialregisters()
        {
            return adminRepository.GetGpcommercialregisters();
        }

        public void HandleRegistarction(int IDD)
        {
            adminRepository.HandleRegistarction(IDD);
        }

        public List<LoaneeCreditScores> loaneeCreditScores()
        {
            return adminRepository.loaneeCreditScores();
        }
    }
}
