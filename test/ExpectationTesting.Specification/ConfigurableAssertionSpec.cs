using System;
using System.Linq.Expressions;
using ExpectationTesting.Rules;
using ExpectationTesting.Specification.TestsObjects;
using FluentAssertions;
using Xunit;

namespace ExpectationTesting.Specification
{
    public class ConfigurableAssertionSpec
    {

        /*public class SimpleRule<T,TProp>:IRule<T>
        {
            private readonly Expression<Func<T, TProp>> propExpression;

            public SimpleRule(Expression<Func<T,TProp>> propExpression ,Func<TProp>)
            {
                this.propExpression = propExpression;
            }

            public bool Assert(T original, T current)
            {
                var original
            }
        }*/

        [Fact]
        public void Assert_Should_Return_True_If_Havent_Rules()
        {
            var entity = new Entity();
            var assertion = Except.That(entity);
            assertion.Assert().Should().BeTrue();
        }

       /* [Fact]
        public void Can_Add_Simple_Rule_Then_Assert()
        {
            var entity = new Entity();
            var assertion = Except.That(entity);
            assertion.AddRule(new SimpleRule<Entity,int>(entity1 => entity.Id));
            assertion.Assert().Should().BeTrue();
        }*/
    }
}