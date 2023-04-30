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

        public void CreateLoan(Gploan loan)
        {
            loanRepository.CreateLoan(loan);
        }

        public void DeleteLoan(int IDD)
        {
            loanRepository.DeleteLoan(IDD);
        }

        public List<Gploan> GetAllLoans()
        {
            return loanRepository.GetAllLoans();
        }

        public List<RequestedLoan> GetAllRequestedLoan(int LSID,int statuss)
        {
            return loanRepository.GetAllRequestedLoan(LSID, statuss);
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
    }
}
