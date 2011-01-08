using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        IFitnessUserRepository fitnessUserRepository = null;

        //
        // Dependency Injection enabled constructors

        public HomeController() : this(new FitnessUserRepository()) { }

        public HomeController(IFitnessUserRepository repository)
        {
            fitnessUserRepository = repository;
        }

        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to FitnessTracker!";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [Authorize]
        public ActionResult PostRegisterUser()
        {
            try
            {
                FitnessUser currentUser = fitnessUserRepository.FindByUserName(User.Identity.Name).SingleOrDefault();
                if (currentUser == null)
                {
                    fitnessUserRepository.AddUserByNameIfNotExists(User.Identity.Name);
                    fitnessUserRepository.Save();
                }
                return RedirectToAction("Index", "WorkoutRegimen");
            }
            catch
            {
                return View("UserCreateError");
            }
        }

    }
}
