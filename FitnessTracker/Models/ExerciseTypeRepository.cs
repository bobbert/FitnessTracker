using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace FitnessTracker.Models
{
    public class ExerciseTypeRepository : IExerciseTypeRepository 
    {
        public FitnessTrackerDataContext DataContext { get; private set; }

        // Constructors

        public ExerciseTypeRepository() : this(new FitnessTrackerDataContext()) { }

        public ExerciseTypeRepository(FitnessTrackerDataContext dataContext)
        {
            DataContext = dataContext;
        }

        //
        // Query Methods

        public IQueryable<ExerciseType> FindByName(string name)
        {
            return DataContext.ExerciseTypes.Where(d => (d.Name == name));
        }

        public IQueryable<ExerciseType> FindAllExerciseTypes()
        {
            return DataContext.ExerciseTypes;
        }

        public ExerciseType GetExerciseType(int id)
        {
            return DataContext.ExerciseTypes.SingleOrDefault(d => d.ExerciseTypeId == id);
        }

        //
        // Insert/Delete Methods

        public void Add(ExerciseType exerciseType)
        {
            DataContext.ExerciseTypes.InsertOnSubmit(exerciseType);
        }

        public void Delete(ExerciseType exerciseType)
        {
            DataContext.ExerciseTypes.DeleteOnSubmit(exerciseType);
        }

        //
        // Persistence 

        public void Save()
        {
            DataContext.SubmitChanges();
        }

    }
}
