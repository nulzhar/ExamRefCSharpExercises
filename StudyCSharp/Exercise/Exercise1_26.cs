using System;
using System.Linq;

namespace StudyCSharp.Exercise
{
    public class Exercise1_26 : IExercise
    {
        public int code() => 126;

        public void Execute()
        {
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers.AsParallel()
                .Where(i => i % 2 == 0);
            parallelResult.ForAll(e => Console.WriteLine(e));
        }
    }
}
