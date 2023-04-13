using Neqatcom.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Repository
{
   public interface ILoaneeRepository
    {
        void CreateLoanee(Gploanee loanee);
        void UpdateLoanee(Gploanee loanee);
        void DeleteLoanee(int IDD);
        Gploanee GetLoaneeByID(int IDD);
        List<Gploanee> GetAllLoanees();
    }
}
