﻿using System.Linq.Expressions;

namespace SpecificationPattern
{
    public sealed class NotSpecification<T>(Specification<T> specification) : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            var expression = specification.ToExpression();
            var notExpression = Expression.Not(expression.Body);

            return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
        }
    }
}