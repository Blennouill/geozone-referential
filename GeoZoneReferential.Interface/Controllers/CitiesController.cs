using GeoZoneReferential.Domain.Entities;
using GeoZoneReferential.Domain.Interfaces;
using GeoZoneReferential.Interface.Models;
using GeoZoneReferential.Interface.Utils.Routing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoZoneReferential.Interface.Controllers
{
    /// <summary>
    /// Countries controller
    /// </summary>
    [Route("api/[controller]")]
    public partial class CitiesController : ControllerBase
    {
        /// <summary>
        /// City service
        /// </summary>
        private readonly IEntityService<City> _cityService;

        /// <summary>
        /// Default controller
        /// </summary>
        /// <param name="countryService"></param>
        public CitiesController(IEntityService<City> cityService)
        {
            _cityService = cityService;
        }

        /// <summary>
        /// Is used to search cities and return the result
        /// </summary>
        /// <param name="cityResearchModel">contains differents parameters to research cities</param>
        [HttpGet]
        public IActionResult Search(CityResearchModel cityResearchModel)
        {
            IReadOnlyList<City> countries = _cityService.Search(cityResearchModel.Build());

            if (!countries.Any())
                return new NotFoundResult();

            return new OkObjectResult(countries);
        }

        /// <summary>
        /// Is used to get a city with its id
        /// </summary>
        /// <param name="id">the id of the country</param>
        [HttpGet("{id}", Name = CitiesRoutingName.CITIES_GET_UNIQUE)]
        public IActionResult Get(int id)
        {
            City city = _cityService.GetByID(id);
            if (city == null)
                return new NotFoundResult();

            return new OkObjectResult(city);
        }
    }
}
