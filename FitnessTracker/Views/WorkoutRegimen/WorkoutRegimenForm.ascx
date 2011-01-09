<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FitnessTracker.Models.WorkoutRegimenFormViewModel>" %>

<% using (Html.BeginForm()) {%>
    <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.WorkoutRegimen.ExerciseTypeId) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.WorkoutRegimen.ExerciseTypeId,
                                         Model.ExerciseTypeList)%>
                <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.ExerciseTypeId) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.WorkoutRegimen.StartDate) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.WorkoutRegimen.StartDate, String.Format("{0:g}", Model.WorkoutRegimen.StartDate))%>
                <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.StartDate) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.WorkoutRegimen.NumWeeks) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.WorkoutRegimen.NumWeeks,
                                         Model.NumWeeksList)%>
                <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.NumWeeks) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.WorkoutRegimen.DaysPerWeek) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.WorkoutRegimen.DaysPerWeek,
                                         Model.DaysInWeekList)%>
                <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.DaysPerWeek) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.WorkoutRegimen.StartingNumMiles) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.WorkoutRegimen.StartingNumMiles, String.Format("{0:F}", Model.WorkoutRegimen.StartingNumMiles))%>
                <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.StartingNumMiles) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.WorkoutRegimen.FinishingNumMiles) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.WorkoutRegimen.FinishingNumMiles, String.Format("{0:F}", Model.WorkoutRegimen.FinishingNumMiles))%>
                <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.FinishingNumMiles) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.WorkoutRegimen.StartingTotalSeconds) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.WorkoutRegimen.StartingTotalSeconds) %>
                <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.StartingTotalSeconds) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.WorkoutRegimen.FinishingTotalSeconds) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.WorkoutRegimen.FinishingTotalSeconds) %>
                <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.FinishingTotalSeconds) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

<% } %>
