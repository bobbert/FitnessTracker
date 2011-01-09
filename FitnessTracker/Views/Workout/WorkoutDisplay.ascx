<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FitnessTracker.Models.WorkoutFormViewModel>" %>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%= Html.Encode(Model.Workout.WorkoutId) %></div>
        
        <div class="display-label">Starting Time</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:g}", Model.Workout.StartingTime))%></div>
        
        <div class="display-label"># of Miles</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:F}", Model.Workout.NumMiles))%></div>
        
        <div class="display-label">Total Seconds</div>
        <div class="display-field"><%= Html.Encode(Model.Workout.TotalSeconds)%></div>
        
    </fieldset>
