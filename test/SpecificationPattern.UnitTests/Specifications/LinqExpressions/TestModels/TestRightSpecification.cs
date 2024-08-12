using System.Linq.Expressions;
using SpecificationPattern.LinqExpressions;

namespace SpecificationPattern.UnitTests.Specifications.LinqExpressions.TestModels
{
    internal sealed class TestRightSpecification(bool value) : Specification<TestModel>
    {
        public override Expression<Func<TestModel, bool>> ToExpression() => model => model.RightValue == value;
    }
}