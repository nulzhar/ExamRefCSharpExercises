using System.Collections.Generic;
using System.Linq;

namespace StudyCSharp.Exercise
{
    public class ExerciseFactory
    {
        public static readonly IEnumerable<IExercise> _exercises = typeof(Exercises).GetFields().Select(property => (IExercise)property.GetValue(null));

        public static IExercise Create(int code)
        {
            return _exercises.FirstOrDefault(exercise => exercise.code() == code);
        }
    }
}
