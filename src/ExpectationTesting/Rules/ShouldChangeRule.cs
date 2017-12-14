using System;

namespace ExpectationTesting.Rules
{
    internal class ShouldChangeRule<T, TProp> : IRule<T> where T:class
    {
        private readonly Func<T, TProp> expression;

        public ShouldChangeRule(Func<T, TProp> expression)
        {
            this.expression = expression;
        }

        public bool Assert(T original, T current)
        {
            var originalValue = expression(original);
            var currentValue = expression(current);
            return !Equals(currentValue, originalValue);
        }
    }
}