using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace StudyCSharp.Exercise
{
    public class Exercice1_28 : IExercise
    {
        public int code() => 128;

        public void Execute()
        {
            var col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(col.Take());
                }
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    var s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                }
            });

            write.Wait();
        }
    }
}
