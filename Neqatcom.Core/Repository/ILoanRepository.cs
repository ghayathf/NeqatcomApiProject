﻿using Neqatcom.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Repository
{
   public interface ILoanRepository
    {
        void CreateLoan(Gploan loan);
        void UpdateLoan(Gploan loan);
        void DeleteLoan(int IDD);
        Gploan GetLoanByID(int IDD);
        List<Gploan> GetAllLoans();
    }
}