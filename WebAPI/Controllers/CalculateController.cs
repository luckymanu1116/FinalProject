using System;
using Library.Repository;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateController : Controller
    {
        private readonly ILogger<CalculateController> _logger;
        private readonly IRepository<WeightDbModel> _repository;

        public CalculateController(ILogger<CalculateController> logger, IRepository<WeightDbModel> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost(Name = "calculateWeight")]
        public String CalculateWeight(WeightDbModel weightDbModel)
        {
            if (weightDbModel.Weight != null && weightDbModel.Amount != null)
            {
                weightDbModel.Weight = Weight.getWeights(WeightDbModel.Weights);
                _repository.Add(WeightDbModel);
                return "SUCCESS";
            }
            return "FAILURE";
        }
    }
}

