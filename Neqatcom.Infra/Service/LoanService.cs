using Neqatcom.Core.Data;
using Neqatcom.Core.DTO;
using Neqatcom.Core.Repository;
using Neqatcom.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Infra.Service
{
   public class LoanService :ILoanService
    {
        private readonly ILoanRepository loanRepository;
        public LoanService(ILoanRepository loanRepository)
        {
            this.loanRepository = loanRepository;
        }

        public void ConfirmNewLoanInfo(Gploan loan)
        {
            loanRepository.ConfirmNewLoanInfo(loan);
        }

        public void CreateLoan(Gploan loan)
        {
            loanRepository.CreateLoan(loan);
        }

        public void DeleteLoan(int IDD)
        {
            loanRepository.DeleteLoan(IDD);
        }

        public int ExistingLoanCounter(int LoaneeID)
        {
            return loanRepository.ExistingLoanCounter(LoaneeID);
        }

        public List<Gploan> GetAllLoans()
        {
            return loanRepository.GetAllLoans();
        }

        public List<RequestedLoan> GetAllRequestedLoan(int LSID,int statuss)
        {
            return loanRepository.GetAllRequestedLoan(LSID, statuss);
        }

        public List<RequestedLoan> GetAllRequestedPostPone(int LSID, int statuss)
        {
            return loanRepository.GetAllRequestedPostPone(LSID, statuss);
        }

        public Gploan GetLoanByID(int IDD)
        {
            return loanRepository.GetLoanByID(IDD);
        }

        public void UpdateLoan(Gploan loan)
        {
            loanRepository.UpdateLoan(loan);
        }

        public void UpdateLoanStatus(int LoanID, int status)
        {
            loanRepository.UpdateLoanStatus(LoanID, status);
        }

        public void UpdatePostponeStatus(int LoanID, int status, int loaneeidd)
        {
            loanRepository.UpdatePostponeStatus(LoanID, status,loaneeidd);
        }
    }
}
