using System;
using System.Linq;

namespace FitnessTracker.Models
{
    public interface IWorkoutRepository : IWorkoutRegimenRepository
    {
        IQueryable<Workout> FindAllWorkoutsByUser(FitnessUser fitnessUser);
        IQueryable<Workout> FindAllWorkoutsByUserAndRegimen(FitnessUser fitnessUser, WorkoutRegimen regimen);

        Workout GetWorkout(FitnessUser fitnessUser, int workoutRegimenId, int workoutId);

        void Add(WorkoutRegimen regimen, Workout workout);
        void Delete(Workout workout);
    }
}
