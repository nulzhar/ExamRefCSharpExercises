using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyCSharp.Exercise
{
    public static class ExerciseFactory
    {
        public static IEnumerable<IExercise> GetExercises()
        {
            var type = typeof(IExercise);
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.GetName().Name == "StudyCSharp")
                .FirstOrDefault().ExportedTypes
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface)
                .Select(t => (IExercise)Activator.CreateInstance(t));
        }

        public static IExercise Create(int code)
        {
            return GetExercises().FirstOrDefault(exercise => exercise.code() == code);
        }
    }
}
