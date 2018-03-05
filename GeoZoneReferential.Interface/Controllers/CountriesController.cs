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
    public class CountriesController : ControllerBase
    {
        /// <summary>
        /// Country service
        /// </summary>
        private readonly IEntityService<Country> _countryService;

        /// <summary>
        /// Default controller
        /// </summary>
        /// <param name="countryService"></param>
        public CountriesController(IEntityService<Country> countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Search(CountryResearchModel countryResearchModel)
        {
            var lEvent = _countryService.GetByUrl(url);
            if (lEvent == null)
                return new NotFoundResult();

            return new OkObjectResult(_eventProcess.GetByUrl(url));
        }

        [HttpGet("{id}", Name = CountriesRoutingName.COUNTRIES_GET_UNIQUE)]
        public IActionResult Get(int id)
        {
            Country country = _countryService.GetByID(id);
            if (country == null)
                return new NotFoundResult();

            return new OkObjectResult(country);
        }

    }
}
