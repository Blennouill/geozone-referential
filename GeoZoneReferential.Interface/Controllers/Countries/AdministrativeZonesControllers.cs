using GeoZoneReferential.Domain.Entities;
using GeoZoneReferential.Domain.Interfaces;
using GeoZoneReferential.Interface.Models;
using GeoZoneReferential.Interface.Utils.Routing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoZoneReferential.Interface.Controllers.Countries
{
    /// <summary>
    /// AdministrativeZone controller
    /// </summary>
    [Route("api/countries/{countryId}/[controller]")]
    public class AdministrativeZonesControllers : ControllerBase
    {
        /// <summary>
        /// Administrative zone service
        /// </summary>
        private readonly IEntityService<AdministrativeZone> _administrativeZoneService;

        /// <summary>
        /// Default controller
        /// </summary>
        /// <param name="countryService"></param>
        public AdministrativeZonesControllers(IEntityService<AdministrativeZone> cityService)
        {
            _administrativeZoneService = cityService;
        }

        /// <summary>
        /// Is used to search cities and return the result
        /// </summary>
        /// <param name="cityResearchModel">contains differents parameters to research cities</param>
        [HttpGet]
        public IActionResult Search(AdimistrativeZoneResearchModel adimistrativeZoneResearchModel)
        {
            var administrativeZones = _administrativeZoneService.Search(adimistrativeZoneResearchModel.Build());

            return new OkObjectResult(administrativeZones);
        }

        /// <summary>
        /// Is used to get a city with its id
        /// </summary>
        /// <param name="id">the id of the country</param>
        [HttpGet("{id}", Name = AdministrativeZoneRoutingName.ADMINISTRATIVEZONES_GET_UNIQUE)]
        public IActionResult Get(int id)
        {
            AdministrativeZone administrativeZone = _administrativeZoneService.GetByID(id);
            if (administrativeZone == null)
                return new NotFoundResult();

            return new OkObjectResult(administrativeZone);
        }
    }
}
