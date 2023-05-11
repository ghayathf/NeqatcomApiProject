﻿using Microsoft.AspNetCore.Http;
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
    public class LoaneeController : ControllerBase
    {
        private readonly ILoaneeService loaneeService;
        public LoaneeController(ILoaneeService loaneeService)
        {
            this.loaneeService = loaneeService;
        }
        [HttpPost]
        [Route("giveComplaintForLender")]
        public void giveComplaintForLender(Gpcomplaint gpcomplaint)
        {
            loaneeService.giveComplaintForLender(gpcomplaint);
        }
        [HttpPost]
        [Route("CreateLoanee")]
        public void CreateLoanee(Gploanee loanee)
        {
            loaneeService.CreateLoanee(loanee);
        }
        [HttpDelete]
        [Route("DeleteLoanee/{id}")]
        public void DeleteLoanee(int id)
        {
            loaneeService.DeleteLoanee(id);
        }
        [HttpGet]
        [Route("GetLoaneeById/{id}")]
        public Gploanee GetLoaneeById(int id)
        {
            return loaneeService.GetLoaneeByID(id);
        }
        [HttpGet]
        [Route("GetAllLoanees")]
        public List<Gploanee> GetAllLoanees()
        {
            return loaneeService.GetAllLoanees();
        }
        [HttpGet]
        [Route("GetAllLoaneeUser")]
        public List<LoaneeUser> GetAllLoaneeUser()
        {
            return loaneeService.GetAllLoaneeUser();
        }
        [HttpPut]
        [Route("UpdateLoanee")]
        public void UpdateLoanee(Gploanee loanee)
        {
            loaneeService.UpdateLoanee(loanee);
        }
        [HttpGet]
        [Route("GetCurrentAndFinishedLoans/{LID}")]
        public List<CurrentAndFinishedLoans> GetCurrentAndFinishedLoans(int LID)
        {
            return loaneeService.GetCurrentAndFinishedLoans(LID);
        }
        [HttpGet]
        [Route("GetConfirmLoans/{loaneeidd}")]
        public List<ConfirmLoans> GetConfirmLoans(int loaneeidd)
        {
            return loaneeService.GetLoansToConfirm(loaneeidd);
        }
    }
}
