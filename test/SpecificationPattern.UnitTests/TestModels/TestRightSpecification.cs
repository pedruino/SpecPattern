using System.Linq.Expressions;

namespace SpecificationPattern.UnitTests.TestModels
{
    internal sealed class TestRightSpecification(bool value) : Specification<TestModel>
    {
        public override Expression<Func<TestModel, bool>> ToExpression() => model => model.RightValue == value;
    }
}