using FluentAssertions;
using SpecificationPattern.LinqExpressions;
using SpecificationPattern.UnitTests.Specifications.LinqExpressions.TestModels;

namespace SpecificationPattern.UnitTests.Specifications.LinqExpressions
{
    public sealed class NotSpecificationUnitTests
    {
        [Fact]
        public void ShouldNegateSpecification()
        {
            // arrange
            var testModel = new TestModel {LeftValue = true};
            var left = new TestLeftSpecification(false);
            var andSpecification = new NotSpecification<TestModel>(left);

            // act
            var isSatisfiedBy = andSpecification.IsSatisfiedBy(testModel);

            // assert
            isSatisfiedBy.Should().BeTrue();
        }
    }
}