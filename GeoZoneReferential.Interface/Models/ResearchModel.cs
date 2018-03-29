using GeoZoneReferential.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GeoZoneReferential.Interface.Models
{
    /// <summary>
    /// Design to describe parameter of research of a city
    /// </summary>
    public abstract class ResearchModel<T>
    {
        private Expression<Func<T, bool>> _currentExpressions;

        protected Expression<Func<T, bool>> CurrentExpressions => _currentExpressions;

        public ResearchModel() { }

        /// <summary>
        /// Is used to build expressions added.
        /// </summary>
        public abstract Expression<Func<T, bool>> Build();

        protected void Add(Expression<Func<T, bool>> expression)
        {
            var paramExpr = Expression.Parameter(typeof(T));
            BinaryExpression exprBody;

            if (_currentExpressions is null)
            {
                _currentExpressions = expression;
            }
            else
            {
                exprBody = Expression.AndAlso(_currentExpressions.Body, expression);
                exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
                var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);
            }
        }

    }
}
