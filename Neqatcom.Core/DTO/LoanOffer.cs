using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.DTO
{
    public class LoanOffer
    {
        public decimal Loanid { get; set; }
        public decimal? Totalmonths { get; set; }
        public decimal? Totalprice { get; set; }
        public decimal? Estimatedprice { get; set; }
        public decimal? Monthlyamount { get; set; }
        public decimal? Predayscounter { get; set; }
        public decimal? Latedayscounter { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public decimal? Offerid { get; set; }
        public decimal? Loaneeid { get; set; }
        public decimal? Loanstatus { get; set; }
        public decimal? Postponestatus { get; set; }
        public string Postponedate { get; set; }
        public string Descriptions { get; set; }
        public decimal? Lenderid { get; set; }
        public decimal? Categoryid { get; set; }
        public decimal? Minmonth { get; set; }
    }
}
