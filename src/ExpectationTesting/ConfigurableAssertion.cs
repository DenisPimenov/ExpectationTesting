using System;
using System.Collections.Generic;
using System.Linq;
using ExpectationTesting.Rules;
using ExpectationTesting.Utils;

namespace ExpectationTesting
{
    public class ConfigurableAssertion<T> where T : class
    {
        private readonly T original;
        private readonly T current;

        private readonly List<IRule<T>> rules = new List<IRule<T>>();

        internal ConfigurableAssertion(T @object)
        {
            original = @object.Copy() ?? throw new ArgumentException("cannot be null", nameof(@object));
            current = @object;
        }

        public bool Assert()
        {
            return rules.Aggregate(true, (result, rule) => result & rule.Assert(original, current));
        }

        public void AddRule(IRule<T> rule)
        {
            rules.Add(rule);
        }
    }
}