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
            return View(exerciseTypeRepository.GetExerciseType(id));
        }

        //
        // GET: /ExerciseType/Create
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ExerciseType/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude="ExerciseTypeId")] ExerciseType exerciseTypeToAdd)
        {
            try
            {
                exerciseTypeRepository.Add(exerciseTypeToAdd);
                exerciseTypeRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /ExerciseType/Edit/5
        public ActionResult Edit(int id)
        {
            return View(exerciseTypeRepository.GetExerciseType(id));
        }

        //
        // POST: /ExerciseType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ExerciseType exerciseTypeToEdit)
        {
            try
            {
                ExerciseType exerciseTypePreviouslySaved = exerciseTypeRepository.GetExerciseType(id);
                UpdateModel(exerciseTypePreviouslySaved);
                exerciseTypeRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ExerciseType/Delete/5
        public ActionResult Delete(int id)
        {
            return View(exerciseTypeRepository.GetExerciseType(id));
        }

        //
        // POST: /ExerciseType/Delete/5
        [HttpPost]
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
