﻿using System.Linq.Expressions;

namespace SpecificationPattern
{
    public sealed class OrSpecification<T>(Specification<T> left, Specification<T> right) : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = left.ToExpression();
            var rightExpression = right.ToExpression();

            var invokedExpression = Expression.Invoke(rightExpression, leftExpression.Parameters);

            return (Expression<Func<T, bool>>)Expression.Lambda(Expression.OrElse(leftExpression.Body, invokedExpression), leftExpression.Parameters);
        }
    }
}