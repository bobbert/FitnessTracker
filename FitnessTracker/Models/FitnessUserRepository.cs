using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace FitnessTracker.Models
{
    public class FitnessUserRepository : IFitnessUserRepository 
    {
        public FitnessTrackerDataContext DataContext { get; private set; }

        // Constructors

        public FitnessUserRepository() : this(new FitnessTrackerDataContext()) { }

        public FitnessUserRepository(FitnessTrackerDataContext dataContext)
        {
            DataContext = dataContext;
        }

        //
        // Query Methods
        public IQueryable<FitnessUser> FindByUserName(string userName)
        {
            return DataContext.FitnessUsers.Where(fu => (fu.UserName == userName));
        }

        public FitnessUser GetFitnessUser(int id)
        {
            return DataContext.FitnessUsers.SingleOrDefault(fu => fu.FitnessUserId == id);
        }

        // Checks if user exists, and adds if non-existant

        public void AddUserByNameIfNotExists(string userName)
        {
            if (FindByUserName(userName).ToList().Count() == 0)
            {
                FitnessUser fitnessUser = new FitnessUser();
                fitnessUser.UserName = userName;
                fitnessUser.DateCreated = DateTime.Now;
                fitnessUser.DateLastVisited = DateTime.Now;
                Add(fitnessUser);
            }
        }

        //
        // Insert/Delete Methods

        public void Add(FitnessUser fitnessUser)
        {
            DataContext.FitnessUsers.InsertOnSubmit(fitnessUser);
        }

        public void Delete(FitnessUser fitnessUser)
        {
            DataContext.FitnessUsers.DeleteOnSubmit(fitnessUser);
        }

        //
        // Persistence 

        public void Save()
        {
            DataContext.SubmitChanges();
        }

    }
}
