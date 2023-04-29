using Neqatcom.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Service
{
    public  interface IOfferService
    {
        List<Gpoffer> GetAllOffers();
        Gpoffer GetOfferById(int id);
        void CreateOffer(Gpoffer offer);
        void UpdateOffer(Gpoffer offer);
        void DeleteOffer(int id);
        List<Gpoffer> GetAllOferById(int id);

    }
}
