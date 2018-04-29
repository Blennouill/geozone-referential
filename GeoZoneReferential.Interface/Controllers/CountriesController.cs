using GeoZoneReferential.Domain.Entities;
using GeoZoneReferential.Domain.Interfaces;
using GeoZoneReferential.Domain.Specifications;
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

        /// <summary>
        /// Is used to search countries and return the result
        /// </summary>
        /// <param name="countryResearchModel">contains differents parameters to research countries</param>
        [HttpGet]
        public IActionResult Search(CountryResearchModel countryResearchModel)
        {
            IReadOnlyList<Country> countries = _countryService.Search(countryResearchModel.Build());

            if (!countries.Any())
                return new NotFoundResult();

            return new OkObjectResult(countries);
        }

        /// <summary>
        /// Is used to get a country with its id
        /// </summary>
        /// <param name="id">the id of the country</param>
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
