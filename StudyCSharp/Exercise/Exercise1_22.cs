using System.Linq;
using System.Threading.Tasks;

namespace StudyCSharp.Exercise
{
    public class Exercise1_22 : IExercise
    {
        public int code() => 122;

        public void Execute()
        {
            Task<bool> t = Task.Run(() =>
            {
                var numbers = Enumerable.Range(0, 100000000);
                var parallelResult = numbers.AsParallel()
                    .Where(i => i % 2 == 0)
                    .ToArray();

                return true;
            });

            t.Wait();
        }
    }
}
