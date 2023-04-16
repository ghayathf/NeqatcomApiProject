using Neqatcom.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Repository
{
    public interface IContactUsRepository
    {
        List<Gpcontactu> GetAllContactUs();
        Gpcontactu GetContactUsByID(int id);
        void CreateContactUs(Gpcontactu contact);
        void UpdateContactUs(Gpcontactu contact);
        void DeleteContactUs(int id);
    }
}
