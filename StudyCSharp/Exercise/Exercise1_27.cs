using System;
using System.Linq;

namespace StudyCSharp.Exercise
{
    public class Exercise1_27 : IExercise
    {
        public int code() => 127;

        public void Execute()
        {
            var numbers = Enumerable.Range(0, 20);
            try
            {
                var parallelResult = numbers.AsParallel()
                    .Where(i => IsEven(i));
                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("There where {0} exceptions", e.InnerExceptions.Count);
            }
        }

        public static bool IsEven(int i)
        {
            if (i % 10 == 0)
            {
                throw new ArgumentException("i");
            }

            return i % 2 == 0; 
        }
    }
}
