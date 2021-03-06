﻿using GeoZoneReferential.Domain.Entities;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace GeoZoneReferential.Domain.Specifications
{
    /// <summary>
    /// Is used to check if url is equal the event url's or the reading url
    /// </summary>
    public sealed class IsContainingWordingSpecification : Specification<Country>
    {
        private readonly string _wording;

        public IsContainingWordingSpecification(string wording)
        {
            _wording = wording;
        }

        public override Expression<Func<Country, bool>> ToExpression()
        {
            return country => country.Wording.ToUpper(CultureInfo.InvariantCulture).Contains(_wording.ToUpper(CultureInfo.InvariantCulture));
        }
    }
}