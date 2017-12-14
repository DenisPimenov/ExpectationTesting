using System;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace ExpectationTesting.Rules
{
    internal static class RulesExt
    {
        [CanBeNull]
        internal static TProp GetPropertyValue<T,TProp>(this Expression<Func<T, TProp>> expression,T obj)
        {
            try
            {
                return expression.Compile().Invoke(obj);
            }
            catch (NullReferenceException)
            {
                return default(TProp);
            }
        }
    }
}