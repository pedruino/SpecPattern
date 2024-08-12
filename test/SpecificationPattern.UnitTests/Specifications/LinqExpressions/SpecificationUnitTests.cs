using FluentAssertions;
using SpecificationPattern.LinqExpressions;
using SpecificationPattern.UnitTests.Specifications.LinqExpressions.TestModels;

namespace SpecificationPattern.UnitTests.Specifications.LinqExpressions
{
    public sealed class SpecificationUnitTests
    {
        [Fact]
        public void WhenSpecificationAllShouldReturnIdentitySpecification()
        {
            // arrange
            // act
            var expression = Specification<object>.All;

            // assert
            expression.Should().BeOfType<IdentitySpecification<object>>();
        }

        [Fact]
        public void WhenLeftIsIdentityShouldReturnRightSpecification()
        {
            // arrange
            var left = TestLeftSpecification.All;
            var right = new TestRightSpecification(true);

            // act
            var expression = left.And(right);

            // assert
            expression.Should().BeSameAs(right);
        }

        [Fact]
        public void WhenRightIsIdentityShouldReturnLeftSpecification()
        {
            // arrange
            var left = new TestLeftSpecification(true);
            var right = TestRightSpecification.All;

            // act
            var expression = left.And(right);

            // assert
            expression.Should().BeSameAs(left);
        }

        [Fact]
        public void WhenLeftAndRightIsNotIdentityShouldReturnAndSpecification()
        {
            // arrange
            var left = new TestLeftSpecification(true);
            var right = new TestLeftSpecification(true);

            // act
            var expression = left.And(right);

            // assert
            expression.Should().BeOfType<AndSpecification<TestModel>>();
        }

        [Fact]
        internal void WhenLeftAndRightIsNotIdentityShouldReturnIdentitySpecification()
        {
            // arrange
            var left = new TestLeftSpecification(true);
            var right = new TestRightSpecification(true);

            // act
            var expression = left.Or(right);

            // assert
            expression.Should().BeOfType<OrSpecification<TestModel>>();
        }

        [Fact]
        internal void WhenNotShouldReturnNotSpecification()
        {
            // arrange
            var left = new TestLeftSpecification(true);

            // act
            var expression = left.Not();

            // assert
            expression.Should().BeOfType<NotSpecification<TestModel>>();
        }


        [Theory]
        [ClassData(typeof(LeftRightOrScenarios))]
        internal void WhenLeftOrRightIsIdentityShouldReturnIdentitySpecification(Specification<TestModel> left,
            Specification<TestModel> right)
        {
            // act
            var expression = left.Or(right);

            // assert
            expression.Should().BeSameAs(IdentitySpecification<TestModel>.All);
        }

        private class LeftRightOrScenarios : TheoryData<Specification<TestModel>, Specification<TestModel>>
        {
            public LeftRightOrScenarios()
            {
                Add(new TestLeftSpecification(true), TestRightSpecification.All);
                Add(TestLeftSpecification.All, new TestRightSpecification(true));
            }
        }
    }
}