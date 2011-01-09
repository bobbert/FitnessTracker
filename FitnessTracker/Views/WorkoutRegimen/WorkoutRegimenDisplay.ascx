<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FitnessTracker.Models.WorkoutRegimenFormViewModel>" %>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.WorkoutRegimenId)%></div>
        
        <div class="display-label">Exercise Type</div>
        <div class="display-field"><%= Html.Encode(Model.GetExerciseTypeName())%></div>
        
        <div class="display-label">Starting Date</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:g}", Model.WorkoutRegimen.StartDate))%></div>
        
        <div class="display-label"># of Weeks</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.NumWeeks)%></div>
        
        <div class="display-label">Days per Week</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.DaysPerWeek)%></div>
        
        <div class="display-label">Starting # of Miles</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:F}", Model.WorkoutRegimen.StartingNumMiles))%></div>
        
        <div class="display-label">Finishing # of Miles</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:F}", Model.WorkoutRegimen.FinishingNumMiles))%></div>
        
        <div class="display-label">Starting Duration (seconds)</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.StartingTotalSeconds)%></div>
        
        <div class="display-label">Finishing Duration (seconds)</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.FinishingTotalSeconds)%></div>
        
    </fieldset>
