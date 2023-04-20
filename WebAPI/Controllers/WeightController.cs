using System;
using Library.Models;
using Library.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeightController : ControllerBase
    {
        private readonly ILogger<WeightController> _logger;
        private readonly IRepository<WeightDbModel> _repository;

        public WeightController(ILogger<WeightController> logger, IRepository<WDbModeeightl> repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpPost(Name = "getWeight")]
        public WeightModel GetWeights(UserIdModel userIdModel)
        {
            List<WeightDbModel> weightModels = new();
            if (userIdModel != null)
            {
                weightModels = _repository.GetAll();
                weightModels = weightModels.FindAll(x => x.UserId == userIdModel.Id);


                return WeightModel;
            }



        }
    }
}

