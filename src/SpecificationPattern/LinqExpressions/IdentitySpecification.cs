using System.Linq.Expressions;

namespace SpecificationPattern.LinqExpressions
{
    public sealed class IdentitySpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression() => x => true;
    }
}