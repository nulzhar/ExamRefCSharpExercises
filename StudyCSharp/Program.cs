using StudyCSharp.Exercise;
using System;

namespace StudyCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Hello Student! You can execute any exercise of 70-483 after input the 'code' or press 'q' to quit this application.");
                Console.WriteLine("Input the exercise code:");
                var input = Console.ReadLine();

                if (input.Length == 1 && input.Equals("q"))
                    break;
                else if (Int32.TryParse(input, out var code))
                    ExecuteExerciseAsync(code);
                else
                    Console.WriteLine("The code is not recognized!");
            }
        }

        static void ExecuteExerciseAsync (int exerciseCode) {
            IExercise Exercise;
            Exercise = ExerciseFactory.Create(exerciseCode);
            if (Exercise == null)
                Console.WriteLine("Error 404! Exercise not found!");
            else
            {
                Exercise.Execute();
                Console.WriteLine("Exercise successfully executed!");
            }
        }
    }
}
