using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    public class ExerciseTypeController : Controller
    {
        IExerciseTypeRepository exerciseTypeRepository;

        //
        // Dependency Injection enabled constructors

        public ExerciseTypeController() : this(new ExerciseTypeRepository()) { }

        public ExerciseTypeController(IExerciseTypeRepository repository)
        {
            exerciseTypeRepository = repository;
        }

        //
        // GET: /ExerciseType/
        public ActionResult Index()
        {
            List<ExerciseType> exerciseTypes = exerciseTypeRepository.FindAllExerciseTypes().ToList();
            return View(exerciseTypes);
        }

        //
        // GET: /ExerciseType/Details/5
        public ActionResult Details(int id)
        {
            ExerciseType exerciseType = exerciseTypeRepository.GetExerciseType(id);
            if (exerciseType == null) return View("NotFound");
            return View(exerciseType);
        }

        //
        // GET: /ExerciseType/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ExerciseType/Create
        [HttpPost, Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Exclude="ExerciseTypeId")] ExerciseType exerciseTypeToAdd)
        {
            try
            {
                exerciseTypeRepository.Add(exerciseTypeToAdd);
                exerciseTypeRepository.Save();
                return RedirectToAction("Details", new { id=exerciseTypeToAdd.ExerciseTypeId });
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /ExerciseType/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            ExerciseType exerciseType = exerciseTypeRepository.GetExerciseType(id);
            if (exerciseType == null) return View("NotFound");
            return View(exerciseType);
        }

        //
        // POST: /ExerciseType/Edit/5
        [HttpPost, Authorize(Roles = "admin")]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            ExerciseType exerciseType = exerciseTypeRepository.GetExerciseType(id);
            try
            {
                UpdateModel(exerciseType);
                exerciseTypeRepository.Save();

                return RedirectToAction("Details", new { id=exerciseType.ExerciseTypeId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ExerciseType/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            ExerciseType exerciseType = exerciseTypeRepository.GetExerciseType(id);
            if (exerciseType == null) return View("NotFound");
            return View(exerciseType);
        }

        //
        // POST: /ExerciseType/Delete/5
        [HttpPost, Authorize(Roles = "admin")]
        public ActionResult Delete(int id, ExerciseType exerciseTypeToDelete)
        {
            try
            {
                ExerciseType exerciseTypePreviouslySaved = exerciseTypeRepository.GetExerciseType(id);
                exerciseTypeRepository.Delete(exerciseTypePreviouslySaved);
                exerciseTypeRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
