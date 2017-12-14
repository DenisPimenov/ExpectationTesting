namespace ExpectationTesting.Rules
{
    public interface IRule<T>
    {
        bool Assert(T original,T current);
    }
}