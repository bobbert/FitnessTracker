using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FitnessTracker.Models
{
    public class WorkoutFormViewModel {

        private ExerciseTypeRepository exerciseTypeRepository;

        public Workout Workout { get; private set; }

        // Constructors

        public WorkoutFormViewModel() : this(new Workout(), new FitnessTrackerDataContext()) { }

        public WorkoutFormViewModel(Workout workout, FitnessTrackerDataContext dc) 
        {
            Workout = workout;
            exerciseTypeRepository =  new ExerciseTypeRepository(dc);
        }

        // Methods invoked within view

    }
}
