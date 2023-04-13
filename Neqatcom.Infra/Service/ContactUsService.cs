using Neqatcom.Core.Data;
using Neqatcom.Core.Repository;
using Neqatcom.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Infra.Service
{
    public class ContactUsService :IContactUsService
    {
        private readonly IContactUsRepository contactUsRepository;

        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            this.contactUsRepository = contactUsRepository;
        }

        public void CreateContactUs(Gpcontactu contact)
        {
            contactUsRepository.CreateContactUs(contact);
        }

        public void DeleteContactUs(int id)
        {
            contactUsRepository.DeleteContactUs(id);
        }

        public List<Gpcontactu> GetAllContactUs()
        {
            return contactUsRepository.GetAllContactUs();
        }

        public Gpcontactu  GetContactUsByID(int id)
        {
            return contactUsRepository.GetContactUsByID(id);
        }

        public void UpdateContactUs(Gpcontactu contact)
        {
            contactUsRepository.UpdateContactUs(contact);
        }
    }
}
