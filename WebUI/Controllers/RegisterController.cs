using System;
using WebUI.Models;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers
{
    public class RegisterController : Controller
    {

        private readonly ILogger<RegisterController> _logger;
        private readonly IToastNotification toastNotification;

        public RegisterController(ILogger<RegisterController> logger, IToastNotification _toastNotification)
        {
            _logger = logger;
            toastNotification = _toastNotification;
        }

        [HttpPost]
        public async Task<IActionResult>? Index(string firstName, string lastName, string email, string password, string repassword)
        {
            UserModel userModel = new UserModel("1", firstName, lastName, email, password);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7249/");

                var result = await client.PostAsJsonAsync<UserModel>("Register", userModel);

                if (result.IsSuccessStatusCode)
                {
                    toastNotification.AddSuccessToastMessage("Registered User " + userModel.FirstName + " successfully");
                    return View("../Home/Index");
                }
                else
                {
                    toastNotification.AddErrorToastMessage("Unable to save user");
                    return View("../Home/Register");
                }
            }

        }
    }
}

