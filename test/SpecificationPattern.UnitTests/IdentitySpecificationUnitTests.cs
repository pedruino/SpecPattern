using System.Linq.Expressions;
using FluentAssertions;

namespace SpecificationPattern.UnitTests
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