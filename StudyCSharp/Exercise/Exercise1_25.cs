using System;
using System.Linq;

namespace StudyCSharp.Exercise
{
    public class Exercise1_25 : IExercise
    {
        public int code() => 125;

        public void Execute()
        {
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers.AsParallel().AsOrdered()
                .Where(i => i % 2 == 0).AsSequential();
            foreach (int i in parallelResult.Take(3))
                Console.WriteLine(i);
        }
    }
}
