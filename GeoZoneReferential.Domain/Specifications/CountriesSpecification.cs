using GeoZoneReferential.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GeoZoneReferential.Domain.Specifications
{
    /// <summary>
    /// Is used to check if url is equal the event url's or the reading url
    /// </summary>
    public class IsContainingWordingSpecification : Specification<Country>
    {
        private readonly string _wording;

        public IsContainingWordingSpecification(string wording)
        {
            _wording = wording;
        }

        public override Expression<Func<Country, bool>> ToExpression()
        {
            return country => country.Wording.ToUpper().Contains(_wording.ToUpper());
        }
    }
}
