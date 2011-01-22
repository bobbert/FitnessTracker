<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FitnessTracker.Models.WorkoutViewModel>" %>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%= Html.Encode(Model.Workout.WorkoutId) %></div>
        
        <div class="display-label">Starting Time</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:g}", Model.Workout.StartingTime))%></div>
        
        <div class="display-label"># of Miles</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:F}", Model.Workout.NumMiles))%></div>

        <div class="display-label">Duration</div>
        <div class="display-field"><%= Html.Encode(Model.Workout.Minutes)%> minutes, 
                                   <%= Html.Encode(Model.Workout.Seconds)%> seconds</div>
    </fieldset>
