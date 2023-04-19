using Neqatcom.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Repository
{
   public interface ILoaneeComplaintsRepository
    {
        void ManageComplaints(int LID);
        List<LoaneeComplaintsDTO> GetAllCompliants();

    }
}
