﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Neqatcom.API.Data
{
    public partial class Gppurchasing
    {
        public decimal Purchaseid { get; set; }
        public DateTime? Paymentdate { get; set; }
        public decimal? Paymenttype { get; set; }
        public decimal? Loanid { get; set; }

        public virtual Gploan Loan { get; set; }
    }
}
