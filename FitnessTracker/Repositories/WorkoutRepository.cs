using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace FitnessTracker.Models
{
    public class WorkoutRepository : WorkoutRegimenRepository, IWorkoutRepository 
    {
        // Constructors

        public WorkoutRepository() : this(new FitnessTrackerDataContext()) { }

        public WorkoutRepository(FitnessTrackerDataContext dataContext)
        {
            DataContext = dataContext;
        }

        //
        // Query Methods

        public IQueryable<Workout> FindAllWorkoutsByUser(FitnessUser fitnessUser)
        {
            return DataContext.Workouts.Where(w => (w.WorkoutRegimen.FitnessUserId == fitnessUser.FitnessUserId));
        }

        public IQueryable<Workout> FindAllWorkoutsByUserAndRegimen(FitnessUser fitnessUser, WorkoutRegimen regimen)
        {
            return DataContext.Workouts.Where(w => (w.WorkoutRegimen.FitnessUserId == fitnessUser.FitnessUserId) &&
                                                   (w.WorkoutRegimenId == regimen.WorkoutRegimenId));
        }

        public Workout GetWorkout(FitnessUser fitnessUser, int workoutRegimenId, int workoutId)
        {
            IQueryable<Workout> workoutQuery = FindAllWorkoutsByUser(fitnessUser).Where(
                w => (w.WorkoutRegimenId == workoutRegimenId) && 
                     (w.WorkoutRegimen.FitnessUserId == fitnessUser.FitnessUserId)
            );
            return workoutQuery.SingleOrDefault(d => d.WorkoutId == workoutId);
        }

        //
        // Insert/Delete Methods

        public void Add(WorkoutRegimen regimen, Workout workout)
        {
            regimen.Workouts.Add(workout);
            DataContext.Workouts.InsertOnSubmit(workout);
        }

        public void Delete(Workout workout)
        {
            DataContext.Workouts.DeleteOnSubmit(workout);
        }
    }
}
