using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace FitnessTracker.Models
{
    partial class Workout
    {
        // Custom fields for managing week-to-week data

        public int WeekNumber
        {
            get { return 1 + ((StartingTime - WorkoutRegimen.StartDate).Days / 7); }
        }

        // Distance custom fields for converting custom distance units to miles

        public string DistanceUnit_Name
        {
            get { return (DistanceUnit == null) ? string.Empty : DistanceUnit.Name; }
        }

        public double? NumMiles
        {
            get
            {
                if (!(NumDistanceUnits.HasValue && DistanceUnitId.HasValue)) return null;
                return NumDistanceUnits / DistanceUnit.UnitsPerMile;
            }
        }

        // Duration custom fields for converting total seconds to minutes/seconds & vice versa

        public int Seconds
        {
            get { return TotalSeconds % 60; }
            set { TotalSeconds = ((TotalSeconds / 60) * 60) + value; }
        }
        public int Minutes
        {
            get { return TotalSeconds / 60; }
            set { TotalSeconds = (value * 60) + (TotalSeconds % 60); }
        }
    }

    partial class WorkoutRegimen
    {
        // Custom fields for managing week-to-week data

        public DateTime FinishDate
        {
            get { return StartDate.AddDays(7 * NumWeeks); }
        }

        public int CurrentWeek
        {
            get 
            { 
                int weekDifference = (DateTime.Now - StartDate).Days / 7; 
                return ((weekDifference > NumWeeks) ? NumWeeks : weekDifference); 
            }
        }

        public double CurrentWeekCompletionPct
        {
            get
            {
                double hoursInCurrentWeek = (DateTime.Now - StartDate).TotalHours % (24.0D * 7.0D);
                return (hoursInCurrentWeek / (24.0D * 7.0D)) * 100.0D;
            }
        }

        public bool IsFinished
        {
            get { return (FinishDate < DateTime.Now); }
        }

        public DateTime StartDateForWeek(int weekNumber)
        {
            if ((weekNumber < 1) || (weekNumber > NumWeeks)) return DateTime.MinValue;
            return StartDate.AddDays(7 * (weekNumber - 1));
        }

        public List<Workout> WorkoutsForWeek(int weekNumber)
        {
            return Workouts.Where(w => w.WeekNumber == weekNumber).ToList();
        }

        public Dictionary<int, List<Workout>> WorkoutsByWeek()
        {
            Dictionary<int, List<Workout>> workoutsByWeek = new Dictionary<int, List<Workout>>();
            for (int weekNum = 1; weekNum <= CurrentWeek; weekNum++)
                workoutsByWeek.Add(weekNum, WorkoutsForWeek(weekNum));
            return workoutsByWeek;
        }

        // Distance custom fields for converting custom distance units to miles

        public string StartingDistanceUnit_Name
        {
            get { return ((StartingDistanceUnit == null) ? string.Empty : StartingDistanceUnit.Name); }
        }
        public string FinishingDistanceUnit_Name
        {
            get { return ((FinishingDistanceUnit == null) ? string.Empty : FinishingDistanceUnit.Name); }
        }

        public bool HasDistanceData()
        {
            return ((ExerciseType.HasDistanceData == 'Y') && (ExerciseType.DefaultDistanceUnitId.HasValue));
        }

        public double? StartingNumMiles
        {
            get
            {
                if (!(StartingNumDistanceUnits.HasValue && StartingDistanceUnitId.HasValue)) return null;
                return StartingNumDistanceUnits / StartingDistanceUnit.UnitsPerMile;
            }
        }
        public double? FinishingNumMiles
        {
            get
            {
                if (!(FinishingNumDistanceUnits.HasValue && FinishingDistanceUnitId.HasValue)) return null;
                return FinishingNumDistanceUnits / FinishingDistanceUnit.UnitsPerMile;
            }
        }

        // Duration custom fields for converting total seconds to minutes/seconds & vice versa

        public int? StartingSeconds {
            get { return StartingTotalSeconds.HasValue ? (StartingTotalSeconds % 60) : null; }
            set { StartingTotalSeconds = value.HasValue ? ((((StartingTotalSeconds.HasValue ? StartingTotalSeconds : 0) / 60) * 60) + value) : null; }
        }
        public int? StartingMinutes {
            get { return StartingTotalSeconds.HasValue ? (StartingTotalSeconds / 60) : null; }
            set { StartingTotalSeconds = value.HasValue ? ((value * 60) + ((StartingTotalSeconds.HasValue ? StartingTotalSeconds : 0) % 60)) : null; }
        }
        public int? FinishingSeconds
        {
            get { return FinishingTotalSeconds.HasValue ? (FinishingTotalSeconds % 60) : null; }
            set { FinishingTotalSeconds = value.HasValue ? ((((FinishingTotalSeconds.HasValue ? FinishingTotalSeconds : 0) / 60) * 60) + value) : null; }
        }
        public int? FinishingMinutes
        {
            get { return FinishingTotalSeconds.HasValue ? (FinishingTotalSeconds / 60) : null; }
            set { FinishingTotalSeconds = value.HasValue ? ((value * 60) + ((FinishingTotalSeconds.HasValue ? FinishingTotalSeconds : 0) % 60)) : null; }
        }
    }
}
