using GeoZoneReferential.Domain.Entities;
using GeoZoneReferential.Interface.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeoZoneReferential.Interface.Controllers.Countries
{
    /// <summary>
    /// AdministrativeZone controller
    /// </summary>
    //[Route("api/countries/{countryId}/[controller]")] ==> This doesnt work for Swashbuckle documentation generator. It needs to be define on the action methode itself. 
    public partial class AdministrativeZonesController : ControllerBase
    {
        /// <summary>
        /// Is used to get the list of administratives zones in a country.
        /// </summary>
        /// <param name="countryId">The id of the parent country.</param>
        [HttpGet("~/api/countries/{countryId}/[controller]/{id}")]
        public IActionResult List(int countryId)
        {
            IReadOnlyList<AdministrativeZone> administrativeZones = _administrativeZoneService.FindListByParentId(countryId);
            if (administrativeZones == null)
                return new NotFoundResult();

            return new OkObjectResult(administrativeZones);
        }
    }
}
