using Neqatcom.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Service
{
   public interface ILoaneeService
    {
        void CreateLoanee(Gploanee loanee);
        void UpdateLoanee(Gploanee loanee);
        void DeleteLoanee(int IDD);
        Gploanee GetLoaneeByID(int IDD);
        List<Gploanee> GetAllLoanees();
    }
}
