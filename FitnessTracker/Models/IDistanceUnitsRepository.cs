using System;
using System.Linq;

namespace FitnessTracker.Models
{
    public interface IDistanceUnitRepository
    {
        FitnessTrackerDataContext DataContext { get; }

        IQueryable<DistanceUnit> FindByDistanceUnitName(string name);
        IQueryable<DistanceUnit> FindAllDistanceUnits();

        DistanceUnit GetDistanceUnit(int distanceUnitId);
        double GetDistanceInMiles(DistanceUnit distanceUnit, double distanceInUnits);
        double GetDistanceInMiles(string name, double distanceInUnits);
        double GetDistanceInUnits(DistanceUnit distanceUnit, double distanceInMiles);
        double GetDistanceInUnits(string name, double distanceInMiles);

        void Add(DistanceUnit distanceUnit);
        void Delete(DistanceUnit distanceUnit);
        void Save();
    }
}
