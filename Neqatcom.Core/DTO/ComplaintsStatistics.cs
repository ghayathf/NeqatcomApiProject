using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.DTO
{
    public class ComplaintsStatistics
    {
        public decimal LOANEETOLENDERCOUNT { get; set; }
        public decimal LENDERTOLOANEECOUNT { get;set; }
        public decimal SYSTEMTOLOANEECOUNT { get; set; }
    }
}
