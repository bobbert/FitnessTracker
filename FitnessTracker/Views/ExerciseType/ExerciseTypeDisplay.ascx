<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FitnessTracker.Models.ExerciseType>" %>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">ExerciseTypeId</div>
        <div class="display-field"><%= Html.Encode(Model.ExerciseTypeId) %></div>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%= Html.Encode(Model.Name) %></div>
        
        <div class="display-label">IsDistanceUsed</div>
        <div class="display-field"><%= Html.Encode(Model.IsDistanceUsed) %></div>
        
        <div class="display-label">MinSecondsPerMile</div>
        <div class="display-field"><%= Html.Encode(Model.MinSecondsPerMile) %></div>
        
        <div class="display-label">MaxSecondsPerMile</div>
        <div class="display-field"><%= Html.Encode(Model.MaxSecondsPerMile) %></div>
        
    </fieldset>
