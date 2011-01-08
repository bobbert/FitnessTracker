using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FitnessTracker.Models
{
    public class WorkoutRegimenFormViewModel {

        private ExerciseTypeRepository exerciseTypeRepository;

        public WorkoutRegimen WorkoutRegimen { get; private set; }
        public SelectList ExerciseTypeList { get; private set; }
        public SelectList DaysInWeekList { get; private set; }
        public SelectList NumWeeksList { get; private set; }

        // Constructors

        public WorkoutRegimenFormViewModel() : this(new WorkoutRegimen(), new FitnessTrackerDataContext()) { }

        public WorkoutRegimenFormViewModel(WorkoutRegimen workoutRegimen, FitnessTrackerDataContext dc) 
        {
            WorkoutRegimen = workoutRegimen;
            exerciseTypeRepository =  new ExerciseTypeRepository(dc);
            ExerciseTypeList = CreateExerciseTypeSelectList(dc);
            DaysInWeekList = CreateDaysInWeekSelectList();
            NumWeeksList = CreateNumWeeksSelectList();
        }

        // Methods invoked within view

        public string GetExerciseTypeName()
        {
            return exerciseTypeRepository.GetExerciseType(WorkoutRegimen.ExerciseTypeId).Name;
        }

        private SelectList CreateExerciseTypeSelectList(FitnessTrackerDataContext dc)
        {
            return new SelectList(exerciseTypeRepository.FindAllExerciseTypes(), "ExerciseTypeId", "Name");
        }

        private SelectList CreateDaysInWeekSelectList()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            IQueryable query = (from i in numbers select i).AsQueryable();
            return new SelectList(query, "DaysPerWeek");
        }

        private SelectList CreateNumWeeksSelectList()
        {
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 52; i++) numbers.Add(i);
            IQueryable query = (from i in numbers select i).AsQueryable();
            return new SelectList(query, "NumWeeks");
        }

    
    }
}
