using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    public class WorkoutController : Controller
    {
        IWorkoutRepository workoutRepository = null;

        //
        // Dependency Injection enabled constructors, such that both repositories use the same DataContext

        public WorkoutController() : this(new WorkoutRepository()) { }

        public WorkoutController(IWorkoutRepository iwr)
        {
            workoutRepository = iwr;
        }

        //
        // GET: /WorkoutRegimen/1/Workout/
        [Authorize]
        public ActionResult Index(int workoutRegimenId)
        {
            try
            {
                FitnessUser currentUser = workoutRepository.FindByUserName(User.Identity.Name).Single();
                WorkoutRegimen parentRegimen = workoutRepository.GetWorkoutRegimen(currentUser, workoutRegimenId);

                IEnumerable<WorkoutFormViewModel> workoutViewModels = (
                        from wr in workoutRepository.FindAllWorkoutsByUserAndRegimen(currentUser, parentRegimen).ToList()
                        select new WorkoutFormViewModel(wr, workoutRepository.DataContext)
                    );
                ViewData["workoutRegimenId"] = workoutRegimenId;  // render Workout Regimen Details based on this value
                return View(workoutViewModels);
            }
            catch
            {
                return View("InvalidUser");
            }
        }

        //
        // GET: /WorkoutRegimen/1/Workout/Details/5
        [Authorize]
        public ActionResult Details(int workoutRegimenId, int id)
        {
            try
            {
                FitnessUser currentUser = workoutRepository.FindByUserName(User.Identity.Name).Single();
                Workout workout = workoutRepository.GetWorkout(currentUser, workoutRegimenId, id);
                if (workout == null) return View("NotFound");
                return View(new WorkoutFormViewModel(workout, workoutRepository.DataContext));
            }
            catch
            {
                return View("InvalidUser");
            }
        }

        //
        // GET: /WorkoutRegimen/1/Workout/Create
        [Authorize]
        public ActionResult Create(int workoutRegimenId)
        {
            Workout workout = new Workout()
            {
                StartingTime = DateTime.Today
            };
            return View(new WorkoutFormViewModel(workout, workoutRepository.DataContext));
        }

        //
        // POST: /WorkoutRegimen/1/Workout/Create
        [HttpPost, Authorize]
        public ActionResult Create(int workoutRegimenId, WorkoutFormViewModel wrfvmToAdd)
        {
            try
            {
                FitnessUser currentUser = workoutRepository.FindByUserName(User.Identity.Name).Single();
                WorkoutRegimen parentRegimen = workoutRepository.GetWorkoutRegimen(currentUser, workoutRegimenId);

                wrfvmToAdd.Workout.WorkoutId = 0; // clear primary key value so that DB can create new value
                workoutRepository.Add(parentRegimen, wrfvmToAdd.Workout);
                workoutRepository.Save();
                return RedirectToAction("Details", new { id = wrfvmToAdd.Workout.WorkoutId });
            }
            catch
            {
                Workout workout = new Workout()
                {
                    StartingTime = DateTime.Today
                };
                return View(new WorkoutFormViewModel(workout, workoutRepository.DataContext));
            }
        }

        //
        // GET: /WorkoutRegimen/1/Workout/Edit/5
        [Authorize]
        public ActionResult Edit(int workoutRegimenId, int id)
        {
            try
            {
                FitnessUser currentUser = workoutRepository.FindByUserName(User.Identity.Name).Single();
                Workout workout = workoutRepository.GetWorkout(currentUser, workoutRegimenId, id);
                if (workout == null) return View("NotFound");
                return View(new WorkoutFormViewModel(workout, workoutRepository.DataContext));
            }
            catch
            {
                return View("InvalidUser");
            }
        }

        //
        // POST: /WorkoutRegimen/1/Workout/Edit/5
        [HttpPost, Authorize]
        public ActionResult Edit(int workoutRegimenId, int id, FormCollection formValues)
        {
            FitnessUser currentUser = null;
            Workout workout = null;
            try
            {
                currentUser = workoutRepository.FindByUserName(User.Identity.Name).Single();
                workout = workoutRepository.GetWorkout(currentUser, workoutRegimenId, id);
            }
            catch
            {
                return View("InvalidUser");
            }
            // try block 2: updating the model -- go back to edit form if invalid
            try
            {
                UpdateModel(workout, "Workout");
                workoutRepository.Save();
                return RedirectToAction("Details", new { id = workout.WorkoutId });
            }
            catch
            {
                return View(new WorkoutFormViewModel(workout, workoutRepository.DataContext));
            }
        }

        //
        // GET: /WorkoutRegimen/1/Workout/Delete/5
        [Authorize]
        public ActionResult Delete(int workoutRegimenId, int id)
        {
            try
            {
                FitnessUser currentUser = workoutRepository.FindByUserName(User.Identity.Name).Single();
                Workout workout = workoutRepository.GetWorkout(currentUser, workoutRegimenId, id);
                if (workout == null) return View("NotFound");
                return View(new WorkoutFormViewModel(workout, workoutRepository.DataContext));
            }
            catch
            {
                return View("InvalidUser");
            }
        }

        //
        // POST: /WorkoutRegimen/1/Workout/Delete/5
        [HttpPost, Authorize]
        public ActionResult Delete(int workoutRegimenId, int id, FormCollection collection)
        {
            try
            {
                FitnessUser currentUser = workoutRepository.FindByUserName(User.Identity.Name).Single();
                Workout workoutPreviouslySaved = workoutRepository.GetWorkout(currentUser, workoutRegimenId, id);
                workoutRepository.Delete(workoutPreviouslySaved);
                workoutRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
