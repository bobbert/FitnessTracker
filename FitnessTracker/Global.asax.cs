using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FitnessTracker
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Workout", 
                "WorkoutRegimens/{WorkoutRegimenId}/Workouts/{action}/{id}",
                new { controller = "Workout", action = "Index",  id = UrlParameter.Optional },
                new { WorkoutRegimenId = @"\d+" }
            );

            routes.MapRoute(
                "WorkoutRegimen",
                "WorkoutRegimens/{action}/{id}",
                new { controller = "WorkoutRegimen", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "ExerciseType", 
                "ExerciseTypes/{action}/{id}", 
                new { controller = "ExerciseType", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}