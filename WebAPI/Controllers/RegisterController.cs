using Library.Repository;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
        private readonly ILogger<RegisterController> _logger;
        private readonly IRepository<UserDbModel> _repository;

        public RegisterController(ILogger<RegisterController> logger, IRepository<UserDbModel> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost(Name = "registerUser")]
        public String RegisterUser(UserModel userModel)
        {
            var userDbModel = new UserDbModel()
            {
                UserId = userModel.Email.Replace("@", "ATTHERATE").Replace(".", "DOT").ToUpper(),
                Email = userModel.Email,
                Password = userModel.Password,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
            };
            _repository.Add(userDbModel);
            return "SUCCESS";
        }

    }
}

