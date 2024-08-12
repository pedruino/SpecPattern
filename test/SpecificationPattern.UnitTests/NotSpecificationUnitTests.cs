using FluentAssertions;
using SpecificationPattern.UnitTests.TestModels;

namespace SpecificationPattern.UnitTests
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