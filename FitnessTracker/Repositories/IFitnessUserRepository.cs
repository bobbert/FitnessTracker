using System;
using System.Linq;

namespace FitnessTracker.Models
{
    public interface IFitnessUserRepository
    {
        FitnessTrackerDataContext DataContext { get; }

        IQueryable<FitnessUser> FindByUserName(string userName);

        FitnessUser GetFitnessUser(int id);
        void AddUserByNameIfNotExists(string userName);

        void Add(FitnessUser fitnessUser);
        void Delete(FitnessUser fitnessUser);
        void Save();
    }
}
