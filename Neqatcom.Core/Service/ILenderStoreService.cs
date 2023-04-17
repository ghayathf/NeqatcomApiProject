using Neqatcom.Core.Data;
using Neqatcom.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Service
{
    public interface ILenderStoreService 
    {
        List<Gplenderstore> GetAllLenderStore();
        List<LenderUser> GetAllLenderUser();
        Gplenderstore GetLenderStoreById(int id);
        void createLenderStore(Gplenderstore gplenderstore);
        void UpdateLenderStore(Gplenderstore gplenderstore);
        void DeleteLenderStore(int id);
    }
}
