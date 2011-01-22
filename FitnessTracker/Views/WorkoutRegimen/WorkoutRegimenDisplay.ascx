<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FitnessTracker.Models.WorkoutRegimenViewModel>" %>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.WorkoutRegimenId)%></div>
        
        <div class="display-label">Exercise Type</div>
        <div class="display-field"><%= Html.ActionLink(Model.GetExerciseTypeName(), "Details", "ExerciseType", new { id = Model.WorkoutRegimen.ExerciseTypeId }, null)%></div>
        
        <div class="display-label">Starting Date</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:g}", Model.WorkoutRegimen.StartDate))%></div>
        
        <div class="display-label"># of Weeks</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.NumWeeks)%></div>
        
        <div class="display-label">Days per Week</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.DaysPerWeek)%></div>

        <% if (Model.HasDistanceData())
            { %>
            <div class="display-label">Starting # of Miles</div>
            <div class="display-field"><%= Html.Encode(String.Format("{0:F}", Model.WorkoutRegimen.StartingNumMiles))%></div>
        
            <div class="display-label">Finishing # of Miles</div>
            <div class="display-field"><%= Html.Encode(String.Format("{0:F}", Model.WorkoutRegimen.FinishingNumMiles))%></div>
        <% } %>
        
        <div class="display-label">Starting Duration</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.StartingMinutes)%> minutes, 
                                   <%= Html.Encode(Model.WorkoutRegimen.StartingSeconds)%> seconds</div>
        
        <div class="display-label">Finishing Duration</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.FinishingMinutes) %> minutes, 
                                   <%= Html.Encode(Model.WorkoutRegimen.FinishingSeconds) %> seconds</div>
        
    </fieldset>
