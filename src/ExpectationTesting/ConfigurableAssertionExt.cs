using System;
using ExpectationTesting.Rules;

namespace ExpectationTesting
{
    public static class ConfigurableAssertionExt
    {
        public static ConfigurableAssertion<T> ShouldChange<T, TProp>(this ConfigurableAssertion<T>assertion,
            Func<T, TProp> expression) where T : class
        {
            assertion.AddRule(new ShouldChangeRule<T,TProp>(expression));
            return assertion;
        }
    }
}