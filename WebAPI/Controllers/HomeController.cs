﻿using Library.Models;
using Library.Repository;
using Library.Validators;
using WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<UserDbModel> _repository;
        public HomeController(ILogger<HomeController> logger, IRepository<UserDbModel> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost(Name = "validateUser")]
        public UserDbModel ValidateUser(LoginModel loginModel)
        {
            if (PasswordValidator.IsValid(loginModel.Password) && EmailValidator.IsValid(loginModel.Email))
            {
                List<UserDbModel> userDbModels = _repository.GetAll();
                var resultUser = userDbModels.Find(userModel => userModel.Email == loginModel.Email && userModel.Password == loginModel.Password);
                if (resultUser != null)
                {
                    return resultUser;
                }
            }
            return new UserDbModel();
        }

    }
}