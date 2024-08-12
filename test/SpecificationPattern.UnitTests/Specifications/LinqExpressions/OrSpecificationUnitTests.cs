using FluentAssertions;
using SpecificationPattern.LinqExpressions;
using SpecificationPattern.UnitTests.Specifications.LinqExpressions.TestModels;

namespace SpecificationPattern.UnitTests.Specifications.LinqExpressions
{
    public sealed class OrSpecificationUnitTests
    {
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, true)]
        [InlineData(false, true, true)]
        public void ShouldSatisfyLeftOrRightSpecification(bool leftValue, bool rightValue, bool expectedSatisfied)
        {
            // arrange
            var testModel = new TestModel {LeftValue = true, RightValue = true};
            var left = new TestLeftSpecification(leftValue);
            var right = new TestRightSpecification(rightValue);
            var andSpecification = new OrSpecification<TestModel>(left, right);

            // act
            var isSatisfiedBy = andSpecification.IsSatisfiedBy(testModel);

            // assert
            isSatisfiedBy.Should().Be(expectedSatisfied);
        }
    }
}