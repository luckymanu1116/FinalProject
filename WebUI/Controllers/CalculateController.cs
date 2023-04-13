using System;
using Library.Models;
using WebUI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static System.Formats.Asn1.AsnWriter;
using NToastNotify;
using WebUI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers
{
    public class CalculateController : Controller
    {
        private readonly ILogger<CalculateController> _logger;
        private readonly IToastNotification toastNotification;

        public CalculateController(ILogger<CalculateController> logger, IToastNotification _toastNotification)
        {
            _logger = logger;
            toastNotification = _toastNotification;
        }

        public async Task<IActionResult> Weights()
        {
            var weights = await GetWeights();
            ViewBag.WeightAmount = weights;
            return View("../Calculate/Weights");
        }

        [HttpPost]
        public async Task<IActionResult>? Index(string username, string password)
        {
            LoginModel loginModel = new(username, password);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7249/");

                var result = await client.PostAsJsonAsync<LoginModel>("Home", loginModel);

                if (result.IsSuccessStatusCode)
                {
                    var user = await result.Content.ReadAsStringAsync();
                    var userDbModel = JsonConvert.DeserializeObject<UserDbModel>(user);
                    Store.User = userDbModel;
                    if (userDbModel != null && userDbModel.Email != null)
                    {
                        toastNotification.AddSuccessToastMessage("Successfully logged in user " + userDbModel.FirstName);
                        return View("../Calculate/Index");
                    }
                    toastNotification.AddErrorToastMessage("Invalid Credentials! login failed");
                    return View("../Home/Index");
                }
            }
            toastNotification.AddErrorToastMessage("Server Error. Please contact administrator.");

            return View("../Home/Index");
        }

        [HttpPost]
        public async Task<IActionResult>? Back()
        {
            return View("../Calculate/Index");
        }

        [HttpPost]
        public async Task<IActionResult>? SaveWeight(string WeightAmount)
        {
            WeightDbModel expenseModel = new WeightDbModel()
            {
                _id = Store.User.UserId + DateTime.Now.ToString(),
                Amount = weightAmount,
                Date = DateTime.Now.ToString(),
                UserId = Store.User.UserId
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7249/");

                var result = await client.PostAsJsonAsync<WeightDbModel>("Calculate", weightModel);

                if (result.IsSuccessStatusCode)
                {
                    toastNotification.AddSuccessToastMessage("Weight with amount " + weightAmount + " saved succesfully for user");
                    return View("../Calculate/Index");
                }
                else
                {
                    toastNotification.AddErrorToastMessage("Saving weight failed for the user");
                    return View("../Calculate/Index");
                }
            }
        }
    }
}

