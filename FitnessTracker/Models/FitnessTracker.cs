namespace FitnessTracker.Models
{
    partial class Workout
    {
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
