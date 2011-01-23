namespace FitnessTracker.Models
{
    partial class Workout
    {
        public string DistanceUnit_Name
        {
            get { if (DistanceUnit == null) return string.Empty; return DistanceUnit.Name; }
        }

        // Distance custom fields for converting custom distance units to miles

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

        // Distance custom fields for converting custom distance units to miles

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
