using System;
using System.Linq;

namespace FitnessTracker.Models
{
    public interface IExerciseTypeRepository : IDistanceUnitRepository
    {
        IQueryable<ExerciseType> FindAllExerciseTypes();
        IQueryable<ExerciseType> FindByExerciseTypeName(string name);

        ExerciseType GetExerciseType(int id);
        double? GetMinSecondsPerUnit(ExerciseType exerciseType, DistanceUnit distanceUnit);
        double? GetMaxSecondsPerUnit(ExerciseType exerciseType, DistanceUnit distanceUnit);

        void Add(ExerciseType exerciseType);
        void Delete(ExerciseType exerciseType);
    }
}
