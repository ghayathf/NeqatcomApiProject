using Neqatcom.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Service
{
    public interface ILenderStoreService 
    {
        List<Gplenderstore> GetAllLenderStore();
        Gplenderstore GetLenderStoreById(int id);
        void createLenderStore(Gplenderstore gplenderstore);
        void UpdateLenderStore(Gplenderstore gplenderstore);
        void DeleteLenderStore(int id);
    }
}
