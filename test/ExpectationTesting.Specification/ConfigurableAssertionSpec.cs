using System;
using ExpectationTesting.Rules;
using ExpectationTesting.Specification.TestsObjects;
using FluentAssertions;
using Xunit;

namespace ExpectationTesting.Specification
{
    public class ConfigurableAssertionSpec
    {
        public class SimpleRule<T,TProp>:IRule<T>
        {
            private readonly Func<T, TProp> propFunc;
            private readonly Func<TProp, bool> condition;

            public SimpleRule(Func<T,TProp> propFunc ,Func<TProp,bool> condition)
            {
                this.propFunc = propFunc;
                this.condition = condition;
            }

            public bool Assert(T original, T current)
            {
                return condition.Invoke(propFunc.Invoke(current));
            }
        }

        [Fact]
        public void Assert_Should_Return_True_If_Havent_Rules()
        {
            var entity = new Entity();
            var assertion = Except.That(entity);
            assertion.Assert().Should().BeTrue();
        }

        [Fact]
        public void Can_Add_Simple_Rule_Then_Assert()
        {
            var entity = new Entity();
            var assertion = Except.That(entity);
            assertion.AddRule(new SimpleRule<Entity,int>(_ => _.Id,i => i>100));
            entity.Id = 200;
            var result = assertion.Assert();
            result.Should().BeTrue();
        }
    }
}