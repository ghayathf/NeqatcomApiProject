﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neqatcom.Core.Data;
using Neqatcom.Core.Service;
using System.Collections.Generic;

namespace Neqatcom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {

        private readonly IContactUsService contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            this.contactUsService = contactUsService;
        }

        [HttpPost]
        [Route("CreateContactUs")]
        public void CreateContactUs(Gpcontactu contact)
        {
            contactUsService.CreateContactUs(contact);
        }
        [HttpDelete]
        [Route("DeleteContactUs/{id}")]
        public void DeleteContactUs(int id)
        {
            contactUsService.DeleteContactUs(id);
        }
        [HttpGet]
        [Route("GetContactUsByID/{id}")]
        public Gpcontactu GetContactUsByID(int id)
        {
            return contactUsService.GetContactUsByID(id);
        }
        [HttpGet]
        [Route("GetAllContactUs")]
        public List<Gpcontactu> GetAllContactUs()
        {
            return contactUsService.GetAllContactUs();
        }
        [HttpPut]
        [Route("UpdateContactUs")]
        public void UpdateContactUs(Gpcontactu contact)
        {
            contactUsService.UpdateContactUs(contact);
        }
    }
}
