using GeoZoneReferential.Domain.Entities;
using GeoZoneReferential.Domain.Interfaces;
using GeoZoneReferential.Interface.Models;
using GeoZoneReferential.Interface.Utils.Routing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeoZoneReferential.Interface.Controllers
{
    /// <summary>
    /// AdministrativeZoneLevel controller.
    /// </summary>
    [Route("api/[controller]")]
    public class AdministrativeLevelZonesController : ControllerBase
    {
        /// <summary>
        /// Administrative level zone service.
        /// </summary>
        private readonly IEntityService<AdministrativeLevelZone> _administrativeLevelZoneService;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AdministrativeLevelZonesController(IEntityService<AdministrativeLevelZone> administrativeLevelZoneService)
        {
            _administrativeLevelZoneService = administrativeLevelZoneService;
        }

        /// <summary>
        /// Is used to get an administrative level zone with its id.
        /// </summary>
        /// <param name="id">The id of the administrative zone level.</param>
        [HttpGet("{id}", Name = AdministrativeLevelZoneRoutingName.ADMINISTRATIVELEVELZONES_GET_UNIQUE)]
        public IActionResult Get(int id)
        {
            AdministrativeLevelZone administrativeLevelZone = _administrativeLevelZoneService.GetByID(id);
            if (administrativeLevelZone == null)
                return new NotFoundResult();

            return new OkObjectResult(administrativeLevelZone);
        }
    }
}
