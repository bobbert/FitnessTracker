using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace FitnessTracker.Models
{
    public class ExerciseTypeRepository : IExerciseTypeRepository 
    {
        private FitnessTrackerDataContext _db;

        public ExerciseTypeRepository() 
        {
            _db = new FitnessTrackerDataContext(); 
        } 

        //
        // Query Methods

        public IQueryable<ExerciseType> FindByName(string name)
        {
            return _db.ExerciseTypes.Where(d => (d.Name == name));
        }

        public IQueryable<ExerciseType> FindAllExerciseTypes()
        {
            return _db.ExerciseTypes;
        }

        public ExerciseType GetExerciseType(int id)
        {
            return _db.ExerciseTypes.SingleOrDefault(d => d.ExerciseTypeId == id);
        }

        //
        // Insert/Delete Methods

        public void Add(ExerciseType exerciseType)
        {
            _db.ExerciseTypes.InsertOnSubmit(exerciseType);
        }

        public void Delete(ExerciseType exerciseType)
        {
            _db.ExerciseTypes.DeleteOnSubmit(exerciseType);
        }

        //
        // Persistence 

        public void Save()
        {
            _db.SubmitChanges();
        }

    }
}
