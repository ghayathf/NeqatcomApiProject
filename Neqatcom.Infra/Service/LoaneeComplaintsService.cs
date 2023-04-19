﻿using Neqatcom.Core.DTO;
using Neqatcom.Core.Repository;
using Neqatcom.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Infra.Service
{
    public class LoaneeComplaintsService : ILoaneeComplaintsService
    {
        private readonly ILoaneeComplaintsRepository LCRepository;
        public LoaneeComplaintsService(ILoaneeComplaintsRepository LCRepository)
        {
            this.LCRepository = LCRepository;
        }

        public List<LoaneeComplaintsDTO> GetAllCompliants()
        {
            return LCRepository.GetAllCompliants();
        }

        public void ManageComplaints(int LID)
        {
            LCRepository.ManageComplaints(LID);
        }
    }
}