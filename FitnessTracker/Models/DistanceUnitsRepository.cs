using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace FitnessTracker.Models
{
    public class DistanceUnitRepository : IDistanceUnitRepository
    {
        public FitnessTrackerDataContext DataContext { get; protected set; }

        // Constructors

        public DistanceUnitRepository() : this(new FitnessTrackerDataContext()) { }

        public DistanceUnitRepository(FitnessTrackerDataContext dataContext)
        {
            DataContext = dataContext;
        }

        //
        // Query Methods

        public IQueryable<DistanceUnit> FindByDistanceUnitName(string name)
        {
            return DataContext.DistanceUnits.Where(d => (d.Name == name));
        }

        public IQueryable<DistanceUnit> FindAllDistanceUnits()
        {
            return DataContext.DistanceUnits;
        }

        public DistanceUnit GetDistanceUnit(int distanceUnitId)
        {
            return DataContext.DistanceUnits.SingleOrDefault(d => d.DistanceUnitId == distanceUnitId);
        }

        public double GetDistanceInMiles(DistanceUnit distanceUnit, double distanceInUnits)
        {
            return distanceInUnits / distanceUnit.UnitsPerMile;
        }

        public double GetDistanceInMiles(string name, double distanceInUnits)
        {
            return GetDistanceInMiles(FindByDistanceUnitName(name).SingleOrDefault(), distanceInUnits);
        }

        public double GetDistanceInUnits(DistanceUnit distanceUnit, double distanceInMiles)
        {
            return distanceInMiles * distanceUnit.UnitsPerMile;
        }

        public double GetDistanceInUnits(string name, double distanceInMiles)
        {
            return GetDistanceInUnits(FindByDistanceUnitName(name).SingleOrDefault(), distanceInMiles);
        }

        //
        // Insert/Delete Methods

        public void Add(DistanceUnit distanceUnit)
        {
            DataContext.DistanceUnits.InsertOnSubmit(distanceUnit);
        }

        public void Delete(DistanceUnit distanceUnit)
        {
            DataContext.DistanceUnits.DeleteOnSubmit(distanceUnit);
        }

        //
        // Persistence 

        public void Save()
        {
            DataContext.SubmitChanges();
        }

    }
}
