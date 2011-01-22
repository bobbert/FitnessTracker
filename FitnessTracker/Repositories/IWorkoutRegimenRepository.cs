using System;
using System.Linq;

namespace FitnessTracker.Models
{
    public interface IWorkoutRegimenRepository : IFitnessUserRepository
    {
        IQueryable<WorkoutRegimen> FindAllWorkoutRegimensByUser(FitnessUser fitnessUser);
        IQueryable<WorkoutRegimen> FindAllCurrentWorkoutRegimensByDate(FitnessUser fitnessUser, DateTime dateTime);
        IQueryable<WorkoutRegimen> FindAllFinishedWorkoutRegimens(FitnessUser fitnessUser, DateTime dateTime);
        IQueryable<WorkoutRegimen> FindByExerciseType(FitnessUser fitnessUser, ExerciseType exerciseType);

        WorkoutRegimen GetWorkoutRegimen(FitnessUser fitnessUser, int id);

        void Add(FitnessUser fitnessUser, WorkoutRegimen exerciseType);
        void Delete(FitnessUser fitnessUser, WorkoutRegimen exerciseType);
    }
}
