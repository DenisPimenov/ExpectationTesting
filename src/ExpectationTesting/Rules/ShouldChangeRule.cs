using System;

namespace ExpectationTesting.Rules
{
    internal class ShouldChangeRule<T, TProp> : IRule where T:class
    {
        private readonly T Object;
        private readonly TProp originalValue;
        private readonly Func<T, TProp> expression;

        public ShouldChangeRule(T @object,Func<T, TProp> expression)
        {
            Object = @object;
            originalValue = expression(@object);
            this.expression = expression;
        }

        public bool Assert()
        {
            var currentValue = expression(Object);
            return !Equals(currentValue, originalValue);
        }
    }
}