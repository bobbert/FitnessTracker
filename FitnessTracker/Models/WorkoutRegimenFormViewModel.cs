using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FitnessTracker.Models
{
    public class WorkoutRegimenFormViewModel : GenericFormViewModel {

        private ExerciseTypeRepository exerciseTypeRepository;

        public WorkoutRegimen WorkoutRegimen { get; private set; }
        public SelectList ExerciseTypeList { get; private set; }
        public SelectList DaysInWeekList { get; private set; }
        public SelectList NumWeeksList { get; private set; }
        public SelectList DistanceUnitTypeList { get; private set; }

        // Constructors

        public WorkoutRegimenFormViewModel() :  this(new WorkoutRegimen(), new FitnessTrackerDataContext()) { }

        public WorkoutRegimenFormViewModel(WorkoutRegimen workoutRegimen, FitnessTrackerDataContext dc) 
        {
            dataContext = dc;
            WorkoutRegimen = workoutRegimen;
            exerciseTypeRepository = new ExerciseTypeRepository(dataContext);
            ExerciseTypeList = CreateExerciseTypeSelectList();
            DaysInWeekList = CreateDaysInWeekSelectList();
            NumWeeksList = CreateNumWeeksSelectList();
            DistanceUnitTypeList = CreateDistanceUnitSelectList();
        }

        // Methods invoked within view

        public string GetExerciseTypeName()
        {
            return exerciseTypeRepository.GetExerciseType(WorkoutRegimen.ExerciseTypeId).Name;
        }

        private SelectList CreateExerciseTypeSelectList()
        {
            return new SelectList(exerciseTypeRepository.FindAllExerciseTypes(), "ExerciseTypeId", "Name");
        }

        private SelectList CreateDistanceUnitSelectList()
        {
            return new SelectList(exerciseTypeRepository.FindAllDistanceUnits(), "DistanceUnitId", "Name");
        }

        private SelectList CreateDaysInWeekSelectList()
        {
            return CreateNumericalSelectList(1, 7, 1, "DaysPerWeek");
        }

        private SelectList CreateNumWeeksSelectList()
        {
            return CreateNumericalSelectList(1, 52, 1, "NumWeeks");
        }    
    }
}
