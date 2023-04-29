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
    public class LoanController : ControllerBase
    {
        private readonly ILoanService loanService;
        public LoanController(ILoanService loanService)
        {
            this.loanService = loanService;
        }
        [HttpPost]
        [Route("CreateLoan")]
        public void CreateLoan(Gploan loan)
        {
            loanService.CreateLoan(loan);
        }
        [HttpDelete]
        [Route("DeleteLoan/{id}")]
        public void DeleteLoan(int id)
        {
            loanService.DeleteLoan(id);
        }
        [HttpGet]
        [Route("GetLoanById/{id}")]
        public Gploan GetLoanById(int id)
        {
            return loanService.GetLoanByID(id);
        }
        [HttpGet]
        [Route("GetAllLoans")]
        public List<Gploan> GetAllLoans()
        {
            return loanService.GetAllLoans();
        }
        [HttpGet]
        [Route("GetAllRequestedLoans/{LSID}")]
        public List<RequestedLoan> GetAllRequestedLoan(int LSID)
        {
            return loanService.GetAllRequestedLoan(LSID);
        }
        [HttpPut]
        [Route("UpdateLoan")]
        public void UpdateLoan(Gploan loan)
        {
            loanService.UpdateLoan(loan);
        }
        [HttpPut]
        [Route("UpdateLoan/{LoanID}/{status}")]
        public void UpdateLoanStatus(int LoanID, int status)
        {
            loanService.UpdateLoanStatus(LoanID, status);
        }

    }
}
