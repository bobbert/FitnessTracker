using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FitnessTracker.Models
{
    public class ExerciseTypeViewModel : GenericViewModel  {

        private ExerciseTypeRepository exerciseTypeRepository;

        public ExerciseType ExerciseType { get; private set; }
        public SelectList HasDistanceDataSelectList { get; private set; }

        // Constructors

        public ExerciseTypeViewModel() : this(new ExerciseType(), new FitnessTrackerDataContext()) { }

        public ExerciseTypeViewModel(ExerciseType exerciseType, FitnessTrackerDataContext dc) 
        {
            dataContext = dc;
            ExerciseType = exerciseType;
            exerciseTypeRepository =  new ExerciseTypeRepository(dc);
            HasDistanceDataSelectList = CreateHasDistanceDataSelectList();
        }

        // Methods invoked within view

        private SelectList CreateHasDistanceDataSelectList()
        {
            return CreateYesNoSelectList("HasDistanceData");
        }

    }
}
