﻿using Dapper;
using Neqatcom.Core.Common;
using Neqatcom.Core.Data;
using Neqatcom.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Neqatcom.Infra.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly IDbContext _dbContext;

        public void CreateUser(Gpuser user)
        {
            var p = new DynamicParameters();
            p.Add("Fname", user.Firstname, dbType: DbType.String, ParameterDirection.Input);
            p.Add("Lname", user.Lastname, dbType: DbType.String, ParameterDirection.Input);
            p.Add("emaail", user.Email, dbType: DbType.String, ParameterDirection.Input);
            p.Add("pass", user.Password, dbType: DbType.String, ParameterDirection.Input);
            p.Add("phone", user.Phonenum, dbType: DbType.String, ParameterDirection.Input);
            p.Add("addr", user.Address, dbType: DbType.String, ParameterDirection.Input);
            p.Add("R", user.Role, dbType: DbType.String, ParameterDirection.Input);
            p.Add("Uname", user.Username, dbType: DbType.String, ParameterDirection.Input);
            p.Add("img", user.Image, dbType: DbType.String, ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("GP_User_Package.CreateUser", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("idd", id, dbType: DbType.Int32, ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("GP_User_Package.DELETEUser", p, commandType: CommandType.StoredProcedure);
        }

        public List<Gpuser> GetAllUsers()
        {
            IEnumerable<Gpuser> result = _dbContext.Connection.Query<Gpuser>("GP_User_Package.GetAllUsers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Gpuser GetUserById(int id)
        {
            var p = new DynamicParameters();
            p.Add("idd", id, dbType: DbType.Int32, ParameterDirection.Input);
            IEnumerable<Gpuser> result = _dbContext.Connection.Query<Gpuser>("GP_User_Package.GetUserById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateUser(Gpuser user)
        {
            var p = new DynamicParameters();
            p.Add("idd", user.Id, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("Fname", user.Firstname, dbType: DbType.String, ParameterDirection.Input);
            p.Add("Lname", user.Lastname, dbType: DbType.String, ParameterDirection.Input);
            p.Add("emaail", user.Email, dbType: DbType.String, ParameterDirection.Input);
            p.Add("pass", user.Password, dbType: DbType.String, ParameterDirection.Input);
            p.Add("phone", user.Phonenum, dbType: DbType.String, ParameterDirection.Input);
            p.Add("addr", user.Address, dbType: DbType.String, ParameterDirection.Input);
            p.Add("R", user.Role, dbType: DbType.String, ParameterDirection.Input);
            p.Add("Uname", user.Username, dbType: DbType.String, ParameterDirection.Input);
            p.Add("img", user.Image, dbType: DbType.String, ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("GP_User_Package.UpdateUser", p, commandType: CommandType.StoredProcedure);
        }
    }
}
