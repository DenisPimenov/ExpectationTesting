using System.Collections.Generic;
using System.Linq;
using ExpectationTesting.Rules;

namespace ExpectationTesting
{
    public class ConfigurableAssertion<T> where T : class
    {
        internal  T Object { get; }

        private readonly List<IRule> rules = new List<IRule>();

        internal ConfigurableAssertion(T @object)
        {
            Object = @object;
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