using System.Linq.Expressions;

namespace SpecificationPattern.UnitTests.TestModels
{
    internal sealed class TestLeftSpecification(bool value) : Specification<TestModel>
    {
        public override Expression<Func<TestModel, bool>> ToExpression() => model => model.LeftValue == value;
    }
}