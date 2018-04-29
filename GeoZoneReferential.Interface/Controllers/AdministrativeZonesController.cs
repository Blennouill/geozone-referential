using GeoZoneReferential.Domain.Entities;
using GeoZoneReferential.Domain.Interfaces;
using GeoZoneReferential.Interface.Models;
using GeoZoneReferential.Interface.Utils.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GeoZoneReferential.Interface.Controllers.Countries
{
    /// <summary>
    /// AdministrativeZone controller.
    /// </summary>
    [Route("api/[controller]")]
    public partial class AdministrativeZonesController : ControllerBase
    {
        /// <summary>
        /// Administrative zone service.
        /// </summary>
        private readonly IEntityService<AdministrativeZone> _administrativeZoneService;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AdministrativeZonesController(IEntityService<AdministrativeZone> administrativeZoneService)
        {
            _administrativeZoneService = administrativeZoneService;
        }
        
        /// <summary>
        /// Is used to get an administrative zone with its id.
        /// </summary>
        /// <param name="id">the id of the administrative zone level.</param>
        [HttpGet("{id}", Name = AdministrativeZoneRoutingName.ADMINISTRATIVEZONES_GET_UNIQUE)]
        public IActionResult Get(int id)
        {
            AdministrativeZone administrativeZone = _administrativeZoneService.GetByID(id);
            if (administrativeZone == null)
                return new NotFoundResult();

            return new OkObjectResult(administrativeZone);
        }

        /// <summary>
        /// Is used to search cities and return the result.
        /// </summary>
        /// <param name="cityResearchModel">Contains differents parameters to research cities</param>
        [HttpGet]
        public IActionResult Search(AdministrativeZoneResearchModel adimistrativeZoneResearchModel)
        {
            IReadOnlyList<AdministrativeZone> administrativeZones = _administrativeZoneService.Search(adimistrativeZoneResearchModel.Build());

            if (!administrativeZones.Any())
                return new NotFoundResult();


            return new OkObjectResult(administrativeZones);
        }
    }
}
