using System;
using System.Linq;

namespace StudyCSharp.Exercise
{
    public class Exercise1_24 : IExercise
    {
        public int code() => 124;

        public void Execute()
        {
            var numbers = Enumerable.Range(0, 10);
            var parallelResult = numbers.AsParallel().AsOrdered()
                .Where(i => i % 2 == 0)
                .ToArray();
            foreach (int i in parallelResult)
                Console.WriteLine(i);
        }
    }
}
