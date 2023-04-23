using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neqatcom.Core.Data;
using Neqatcom.Core.Service;
using System;
using System.Collections.Generic;
using System.IO;

namespace Neqatcom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Auth([FromBody] Gpuser login)
        {
            var token = userService.Auth(login);
            if(token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public List<Gpuser> GetAllUsers()
        {
            return userService.GetAllUsers();
        }
        [HttpGet]
        [Route("GetUserById/{id}")]
        public Gpuser GetUserById(int id)
        {
            return userService.GetUserById(id);
        }
        [HttpPost]
        [Route("CreateUser")]
        public void CreateUser(Gpuser user)
        {
            userService.CreateUser(user);
        }
        [HttpPut]
        [Route("UpdateUser")]
        public void UpdateUser(Gpuser user)
        {
            userService.UpdateUser(user);
        }
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public void DeleteUser(int id)
        {
            userService.DeleteUser(id);
        }
        [Route("UploadImage")]
        [HttpPost]
        public Gpuser UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullpath = Path.Combine("C:\\neqatcom_Angular\\src\\assets\\HomeAssets\\images", fileName);

            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            Gpuser item = new Gpuser();
            item.Userimage = fileName;
            return item;
        }
    }
}
