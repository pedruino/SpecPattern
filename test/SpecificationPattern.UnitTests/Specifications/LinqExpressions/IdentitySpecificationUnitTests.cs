using System.Linq.Expressions;
using FluentAssertions;
using SpecificationPattern.LinqExpressions;

namespace SpecificationPattern.UnitTests.Specifications.LinqExpressions
{
    public sealed class IdentitySpecificationUnitTests
    {
        [Fact]
        public void WhenIdentitySpecificationShouldReturnTrueExpression()
        {
            // arrange
            Expression<Func<object, bool>> identityExpression = x => true;

            // act
            var expression = new IdentitySpecification<object>().ToExpression();

            // assert
            expression.Should().BeEquivalentTo(identityExpression);
        }
    }
}