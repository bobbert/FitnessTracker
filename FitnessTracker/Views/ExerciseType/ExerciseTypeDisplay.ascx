<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FitnessTracker.Models.ExerciseTypeViewModel>" %>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">ExerciseTypeId</div>
        <div class="display-field"><%= Html.Encode(Model.ExerciseType.ExerciseTypeId) %></div>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%= Html.Encode(Model.ExerciseType.Name) %></div>
        
        <div class="display-label">IsDistanceUsed</div>
        <div class="display-field"><%= Html.Encode(Model.ExerciseType.HasDistanceData)%></div>
        
        <div class="display-label">MinSecondsPerMile</div>
        <div class="display-field"><%= Html.Encode(Model.ExerciseType.MinSecondsPerMile) %></div>
        
        <div class="display-label">MaxSecondsPerMile</div>
        <div class="display-field"><%= Html.Encode(Model.ExerciseType.MaxSecondsPerMile) %></div>
        
    </fieldset>
