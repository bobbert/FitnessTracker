using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace FitnessTracker.Models
{
    public class WorkoutRegimenRepository : IWorkoutRegimenRepository 
    {
        public FitnessTrackerDataContext DataContext { get; private set; }

        // Constructors

        public WorkoutRegimenRepository() : this(new FitnessTrackerDataContext()) { }

        public WorkoutRegimenRepository(FitnessTrackerDataContext dataContext)
        {
            DataContext = dataContext;
        }

        //
        // Query Methods

        public IQueryable<WorkoutRegimen> FindAllWorkoutRegimensByUser(FitnessUser fitnessUser)
        {
            return DataContext.WorkoutRegimens.Where(wr => (wr.FitnessUserId == fitnessUser.FitnessUserId));
        }

        public IQueryable<WorkoutRegimen> FindAllCurrentWorkoutRegimensByDate(FitnessUser fitnessUser, DateTime dateTime)
        {
            var wrbu = FindAllWorkoutRegimensByUser(fitnessUser);
            return wrbu.Where(wr => ((wr.StartDate <= dateTime) &&
                                     (wr.StartDate.AddDays(7 * wr.NumWeeks) >= dateTime)));
        }

        public IQueryable<WorkoutRegimen> FindAllFinishedWorkoutRegimens(FitnessUser fitnessUser, DateTime dateTime)
        {
            var wrbu = FindAllWorkoutRegimensByUser(fitnessUser);
            return wrbu.Where(wr => (wr.StartDate.AddDays(7 * wr.NumWeeks) < dateTime));
        }

        public IQueryable<WorkoutRegimen> FindByExerciseType(FitnessUser fitnessUser, ExerciseType exerciseType)
        {
            var wrbu = FindAllWorkoutRegimensByUser(fitnessUser);
            return wrbu.Where(wr => (wr.ExerciseTypeId == exerciseType.ExerciseTypeId));
        }

        public WorkoutRegimen GetWorkoutRegimen(FitnessUser fitnessUser, int id)
        {
            var wrbu = FindAllWorkoutRegimensByUser(fitnessUser);
            return wrbu.SingleOrDefault(d => d.WorkoutRegimenId == id);
        }

        //
        // Insert/Delete Methods

        public bool isAssociated(FitnessUser fitnessUser, WorkoutRegimen workoutRegimen)
        {
            return (fitnessUser.WorkoutRegimens.Where(
                wr => (wr.WorkoutRegimenId == workoutRegimen.WorkoutRegimenId)
            ).ToList().Count() > 0);
        }

        public void Add(FitnessUser fitnessUser, WorkoutRegimen workoutRegimen)
        {
            fitnessUser.WorkoutRegimens.Add(workoutRegimen);
            DataContext.WorkoutRegimens.InsertOnSubmit(workoutRegimen);
        }

        public void Delete(FitnessUser fitnessUser, WorkoutRegimen workoutRegimen)
        {
            if (!isAssociated(fitnessUser, workoutRegimen))
                throw new ApplicationException(
                    String.Format("Workout regimen #{0} does not belong to user #{1}.", workoutRegimen.WorkoutRegimenId, fitnessUser.FitnessUserId)
                );
            DataContext.WorkoutRegimens.DeleteOnSubmit(workoutRegimen);
        }

        //
        // Persistence 

        public void Save()
        {
            DataContext.SubmitChanges();
        }

    }
}
