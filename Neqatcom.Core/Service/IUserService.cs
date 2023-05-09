using Neqatcom.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Service
{
    public  interface IUserService
    {
        List<Gpuser> GetAllUsers();
        Gpuser GetUserById(int id);
        void CreateUser(Gpuser user);
        void UpdateUser(Gpuser user);
        void DeleteUser(int id);
        string Auth(Gpuser login);
        void updatePassword(Gpuser gpuser);
    }
}
