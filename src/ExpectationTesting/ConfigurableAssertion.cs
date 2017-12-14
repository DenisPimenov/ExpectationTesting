using System;
using System.Collections.Generic;
using System.Linq;
using ExpectationTesting.Rules;
using ExpectationTesting.Utils;
using ExpectationTesting.Utils.Clone;

namespace ExpectationTesting
{
    public class ConfigurableAssertion<T> where T : class
    {
        internal  T Original { get; }
        internal  T Current{ get; }

        private readonly List<IRule> rules = new List<IRule>();

        internal ConfigurableAssertion(T @object)
        {
            Original = @object.Copy() ?? throw new ArgumentException("cannot be null", nameof(@object));
            Current = @object;
        }

        public bool Assert()
        {
            return rules.Aggregate(true, (result, rule) => result & rule.Assert());
        }

        public void AddRule(IRule rule)
        {
            rules.Add(rule);
        }
    }
}