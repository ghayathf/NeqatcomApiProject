using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neqatcom.Core.Data;
using Neqatcom.Core.DTO;
using Neqatcom.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neqatcom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IAdminService adminService;
        private readonly ILoaneeComplaintsService lcService;

        public AdminController(IAdminService adminService,ILoaneeComplaintsService lcService)
        {
            this.adminService = adminService;
            this.lcService = lcService;
        }
        [HttpGet]
        [Route("GetAllCommercialRegistres")]
        public List<Gpcommercialregister> GetAllCommecialregister()
        {
            return adminService.GetGpcommercialregisters();
        }
        [HttpPut]
        [Route("AcceptLenderRegistration/{id}")]
        public void AcceptLenderRegistration(int id)
        {
            adminService.HandleRegistarction(id);
        }
        [HttpPost]
        [Route("ManageLoaneeComplaints/{lid}/{CID}")]
        public void ManageLoaneeComplaints(int lid, int CID)
        {
            lcService.ManageComplaints(lid, CID);
        }
        [HttpGet]
        [Route("GetAllComplaints")]
        public List<LoaneeComplaintsDTO> GetAllComplaints()
        {
            return lcService.GetAllCompliants();
        }
        [HttpPost]
        [Route("CheckFiveDays")]
        public void CheckFiveDays()
        {
            lcService.CheckFiveDays();
        }
        [HttpGet]
        [Route("ActorCounter")]
        public List<ActorCounterDTO> ActorCounter()
        {
            return adminService.ActorCounter();
        }
    }
}
