using Neqatcom.Core.Data;
using Neqatcom.Core.DTO;
using Neqatcom.Core.Repository;
using Neqatcom.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Infra.Service
{
   public class LoaneeService:ILoaneeService
    {
        private readonly ILoaneeRepository loaneeRepository;
        public LoaneeService(ILoaneeRepository loaneeRepository)
        {
            this.loaneeRepository = loaneeRepository;
        }

        public void CreateLoanee(Gploanee loanee)
        {
            loaneeRepository.CreateLoanee(loanee);
        }
        public void giveComplaintForLender(Gpcomplaint gpcomplaint)
        {
            loaneeRepository.giveComplaintForLender(gpcomplaint);
        }
        public List<Gpnationalnumber> GetAllGpnationalnumber()
        {
            return loaneeRepository.GetAllGpnationalnumber();
        }
        public void DeleteLoanee(int IDD)
        {
            loaneeRepository.DeleteLoanee(IDD);
        }

        public List<Gploanee> GetAllLoanees()
        {
            return loaneeRepository.GetAllLoanees();
        }

        public List<LoaneeUser> GetAllLoaneeUser()
        {
            return loaneeRepository.GetAllLoaneeUser();
        }

        public List<CurrentAndFinishedLoans> GetCurrentAndFinishedLoans(int LID)
        {
            return loaneeRepository.GetCurrentAndFinishedLoans(LID);
        }

        public Gploanee GetLoaneeByID(int IDD)
        {
            return loaneeRepository.GetLoaneeByID(IDD);
        }

        public List<ConfirmLoans> GetLoansToConfirm(int loaneeidd)
        {
            return loaneeRepository.GetLoansToConfirm(loaneeidd);
        }

        public void UpdateLoanee(Gploanee loanee)
        {
            loaneeRepository.UpdateLoanee(loanee);
        }
    }
}
