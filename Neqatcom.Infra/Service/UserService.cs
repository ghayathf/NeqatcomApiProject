using Neqatcom.Core.Data;
using Neqatcom.Core.Repository;
using Neqatcom.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Infra.Service
{
    public  class UserService:IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void CreateUser(Gpuser user)
        {
            userRepository.CreateUser(user);
        }

        public void DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
        }

        public List<Gpuser> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public Gpuser GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public void UpdateUser(Gpuser user)
        {
            userRepository.UpdateUser(user);
        }
    }
}
