using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    public class WorkoutRegimenController : Controller
    {
        IWorkoutRegimenRepository workoutRegimenRepository = null;
        IFitnessUserRepository fitnessUserRepository = null;

        //
        // Dependency Injection enabled constructors, such that both repositories use the same DataContext

        public WorkoutRegimenController() : this(new FitnessUserRepository()) { }

        public WorkoutRegimenController(IFitnessUserRepository ifur) : this(ifur, new WorkoutRegimenRepository(ifur.DataContext)) { }

        public WorkoutRegimenController(IFitnessUserRepository ifur, IWorkoutRegimenRepository iwrr)
        {
            fitnessUserRepository = ifur;
            workoutRegimenRepository = iwrr;
        }

        //
        // GET: /WorkoutRegimen/
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                FitnessUser currentUser = fitnessUserRepository.FindByUserName(User.Identity.Name).Single();
                IEnumerable<WorkoutRegimenFormViewModel> workoutRegimenViewModels = (
                        from wr in workoutRegimenRepository.FindAllWorkoutRegimensByUser(currentUser).ToList()
                        select new WorkoutRegimenFormViewModel(wr, workoutRegimenRepository.DataContext)
                    );
                return View(workoutRegimenViewModels);
            }
            catch
            {
                return View("InvalidUser");
            }
        }

        //
        // GET: /WorkoutRegimen/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            try
            {
                FitnessUser currentUser = fitnessUserRepository.FindByUserName(User.Identity.Name).Single();
                WorkoutRegimen workoutRegimen = workoutRegimenRepository.GetWorkoutRegimen(currentUser, id);
                if (workoutRegimen == null) return View("NotFound");
                return View(new WorkoutRegimenFormViewModel(workoutRegimen,
                                                            fitnessUserRepository.DataContext));
            }
            catch
            {
                return View("InvalidUser");
            }
        }

        //
        // GET: /WorkoutRegimen/Create
        [Authorize]
        public ActionResult Create()
        {
            WorkoutRegimen workoutRegimen = new WorkoutRegimen() {
                 StartDate = DateTime.Today 
            };
            return View(new WorkoutRegimenFormViewModel(workoutRegimen,
                                                        fitnessUserRepository.DataContext));
        } 

        //
        // POST: /WorkoutRegimen/Create
        [HttpPost, Authorize]
        public ActionResult Create(WorkoutRegimenFormViewModel wrfvmToAdd)
        {
            try
            {
                FitnessUser currentUser = fitnessUserRepository.FindByUserName(User.Identity.Name).Single();

                wrfvmToAdd.WorkoutRegimen.WorkoutRegimenId = 0; // clear primary key value so that DB can create new value
                workoutRegimenRepository.Add(currentUser, wrfvmToAdd.WorkoutRegimen);
                workoutRegimenRepository.Save();
                string redirectToPage = ((wrfvmToAdd.WorkoutRegimen.ExerciseType.HasDistanceData == 'Y') ? "Edit" : "Details");
                return RedirectToAction(redirectToPage, new { id = wrfvmToAdd.WorkoutRegimen.WorkoutRegimenId });
            }
            catch
            {
                WorkoutRegimen workoutRegimen = new WorkoutRegimen() {
                    StartDate = DateTime.Today
                };
                return View(new WorkoutRegimenFormViewModel(workoutRegimen,
                                                            fitnessUserRepository.DataContext));
            }
        }
        
        //
        // GET: /WorkoutRegimen/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            try
            {
                FitnessUser currentUser = fitnessUserRepository.FindByUserName(User.Identity.Name).Single();
                WorkoutRegimen workoutRegimen = workoutRegimenRepository.GetWorkoutRegimen(currentUser, id);
                if (workoutRegimen == null) return View("NotFound");

                ViewData["Distance"] = true;
                return View(new WorkoutRegimenFormViewModel(workoutRegimen, 
                                                            fitnessUserRepository.DataContext));
            }
            catch
            {
                return View("InvalidUser");
            }
        }

        //
        // POST: /WorkoutRegimen/Edit/5
        [HttpPost, Authorize]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            FitnessUser currentUser = null;
            WorkoutRegimen workoutRegimen = null;
            try
            {
                currentUser = fitnessUserRepository.FindByUserName(User.Identity.Name).Single();
                workoutRegimen = workoutRegimenRepository.GetWorkoutRegimen(currentUser, id);
            }
            catch
            {
                return View("InvalidUser");
            }
            // try block 2: updating the model -- go back to edit form if invalid
            try
            {
                UpdateModel(workoutRegimen, "WorkoutRegimen");
                workoutRegimenRepository.Save();
                return RedirectToAction("Details", new { id=workoutRegimen.WorkoutRegimenId });
            }
            catch
            {
                return View(new WorkoutRegimenFormViewModel(workoutRegimen,
                                                            fitnessUserRepository.DataContext));
            }
        }

        //
        // GET: /WorkoutRegimen/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                FitnessUser currentUser = fitnessUserRepository.FindByUserName(User.Identity.Name).Single();
                WorkoutRegimen workoutRegimen = workoutRegimenRepository.GetWorkoutRegimen(currentUser, id);
                if (workoutRegimen == null) return View("NotFound");
                return View(new WorkoutRegimenFormViewModel(workoutRegimen,
                                                            fitnessUserRepository.DataContext));
            }
            catch
            {
                return View("InvalidUser");
            }
        }

        //
        // POST: /WorkoutRegimen/Delete/5
        [HttpPost, Authorize]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                FitnessUser currentUser = fitnessUserRepository.FindByUserName(User.Identity.Name).Single();
                WorkoutRegimen workoutRegimenPreviouslySaved = workoutRegimenRepository.GetWorkoutRegimen(currentUser, id);
                workoutRegimenRepository.Delete(currentUser, workoutRegimenPreviouslySaved);
                workoutRegimenRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
