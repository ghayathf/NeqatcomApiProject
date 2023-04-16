﻿using Neqatcom.Core.Data;
using Neqatcom.Core.Repository;
using Neqatcom.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Infra.Service
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }
        public void CreateOffer(Gpoffer offer)
        {
            offerRepository.CreateOffer(offer);
        }

        public void DeleteOffer(int id)
        {
            offerRepository.DeleteOffer(id);
        }

        public List<Gpoffer> GetAllOffers()
        {
            return offerRepository.GetAllOffers();
        }

        public Gpoffer GetOfferById(int id)
        {
            return offerRepository.GetOfferById(id);
        }

        public void UpdateOffer(Gpoffer offer)
        {
            offerRepository.UpdateOffer(offer);
        }
    }
}
