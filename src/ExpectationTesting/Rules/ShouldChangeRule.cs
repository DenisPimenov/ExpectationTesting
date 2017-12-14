using System;

namespace ExpectationTesting.Rules
{
    internal class ShouldChangeRule<T, TProp> : IRule where T:class
    {
        private readonly T original;
        private readonly T current;
        private readonly Func<T, TProp> expression;

        public ShouldChangeRule(T original, T current,Func<T, TProp> expression)
        {
            this.original = original;
            this.current = current;
            this.expression = expression;
        }

        public bool Assert()
        {
            var originalValue = expression(original);
            var currentValue = expression(current);
            return !Equals(currentValue, originalValue);
        }
    }
}