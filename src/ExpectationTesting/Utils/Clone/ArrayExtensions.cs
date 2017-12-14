using System;

namespace ExpectationTesting.Utils.Clone.ArrayExtensions
{
    public static class ArrayExtensions
    {
        public static void ForEach(this Array array, Action<Array, int[]> action)
        {
            if (array.LongLength == 0) return;
            var walker = new ArrayTraverse(array);
            do action(array, walker.Position);
            while (walker.Step());
        }
    }
}