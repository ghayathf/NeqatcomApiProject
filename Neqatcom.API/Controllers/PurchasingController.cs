﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neqatcom.Core.Data;
using Neqatcom.Core.Service;
using Neqatcom.Infra.Service;
using System.Collections.Generic;

namespace Neqatcom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasingController : ControllerBase
    {
        private readonly IPurchasingService purchasingrService;

        public PurchasingController(IPurchasingService purchasingrService)
        {
            this.purchasingrService = purchasingrService;
        }
        [HttpGet]
        [Route("GetAllPurchasing")]
        public List<Gppurchasing> GetAllPurchasing()
        {
            return purchasingrService.GetAllPurchasing();
        }
        [HttpGet]
        [Route("GetPurchasingById/{id}")]
        public Gppurchasing GetPurchasingById(int id)
        {
            return purchasingrService.GetPurchasingById(id);
        }
        [HttpPost]
        [Route("CreatePurchasing")]
        public void CreatePurchasing(Gppurchasing purchasing)
        {
            purchasingrService.CreatePurchasing(purchasing);
        }
        [HttpPut]
        [Route("UpdatePurchasing")]
        public void UpdatePurchasing(Gppurchasing purchasing)
        {
            purchasingrService.UpdatePurchasing(purchasing);
        }
        [HttpDelete]
        [Route("DeletePurchasing/{id}")]
        public void DeletePurchasing(int id)
        {
            purchasingrService.DeletePurchasing(id);
        }
        [HttpGet]
        [Route("GettAllPayments/{id}")]
        public List<Gppurchasing> GettAllPayments(int id)
        {
            return purchasingrService.GettAllPayments(id);
        }
    }
}
