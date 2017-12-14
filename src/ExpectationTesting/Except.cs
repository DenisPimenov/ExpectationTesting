namespace ExpectationTesting
{
    public static class Except
    {
        public static ConfigurableAssertion<T> That<T>(T obj) where T : class
        {
            return new ConfigurableAssertion<T>(obj);
        }
    }
}