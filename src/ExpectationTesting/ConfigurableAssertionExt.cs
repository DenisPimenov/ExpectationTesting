using System;
using System.Linq.Expressions;
using ExpectationTesting.Rules;


namespace ExpectationTesting
{
    public static class ConfigurableAssertionExt
    {
        public static ConfigurableAssertion<T> ShouldChange<T, TProp>(this ConfigurableAssertion<T>assertion,
            Expression<Func<T, TProp>> expression) where T : class
        {
            assertion.AddRule(new ShouldChangeRule<T,TProp>(assertion.Object,expression.Compile()));
            return assertion;
        }
    }
}