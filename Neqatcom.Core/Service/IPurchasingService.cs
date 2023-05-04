using Neqatcom.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Service
{
    public interface IPurchasingService
    {
        List<Gppurchasing> GetAllPurchasing();
        Gppurchasing GetPurchasingById(int id);
        void CreatePurchasing(Gppurchasing purchasing);
        void UpdatePurchasing(Gppurchasing purchasing);
        void DeletePurchasing(int id);
        List<Gppurchasing> GettAllPayments(int id);
        void ForGiveMonthly(int id);

    }
}
