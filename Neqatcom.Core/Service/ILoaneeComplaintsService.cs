using Neqatcom.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Service
{
    public interface ILoaneeComplaintsService
    {
        void ManageComplaints(int LID);
        List<LoaneeComplaintsDTO> GetAllCompliants();

    }
}
