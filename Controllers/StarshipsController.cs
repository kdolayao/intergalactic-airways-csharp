using IntergalacticAirways.Models;
using IntergalacticAirways.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace IntergalacticAirways.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StarshipsController : ControllerBase
    {

        private readonly IOptions<AppSettings> _appSettings;
        public StarshipsController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        [HttpGet]
        public List<StarshipsDTO> Get(int passengerNumber)
        {
            var service = new StarshipServices();
            var httpClientServices = new HttpClientServices();

            string swapiUrl = _appSettings.Value.StarWarsApi.Url + _appSettings.Value.StarWarsApi.Endpoints.Starships;

            var model = service.GetStarships(httpClientServices, swapiUrl, passengerNumber);

            return model;
        }
    }
}
