<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FitnessTracker.Models.WorkoutRegimenViewModel>" %>

<% using (Html.BeginForm()) {%>
    <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.WorkoutRegimen.ExerciseTypeId) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.WorkoutRegimen.ExerciseTypeId,
                                         Model.ExerciseTypeList) %>
                <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.ExerciseTypeId) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.WorkoutRegimen.StartDate) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.WorkoutRegimen.StartDate, String.Format("{0:g}", Model.WorkoutRegimen.StartDate)) %>
                <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.StartDate) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.WorkoutRegimen.NumWeeks) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.WorkoutRegimen.NumWeeks,
                                         Model.NumWeeksList) %>
                <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.NumWeeks) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.WorkoutRegimen.DaysPerWeek) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.WorkoutRegimen.DaysPerWeek,
                                         Model.DaysInWeekList) %>
                <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.DaysPerWeek) %>
            </div>
            
            <% if (ViewData["Distance"] != null)
               { %>
               <% if (Model.HasDistanceData())
                  { %>

                    <div class="editor-label">
                        <%= Html.LabelFor(model => model.WorkoutRegimen.StartingNumDistanceUnits)%>
                    </div>
                    <div class="editor-field">
                        <%= Html.TextBoxFor(model => model.WorkoutRegimen.StartingNumDistanceUnits, String.Format("{0:F}", Model.WorkoutRegimen.StartingNumDistanceUnits))%>
                        <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.StartingNumDistanceUnits)%>

                        <%= Html.DropDownListFor(model => model.WorkoutRegimen.StartingDistanceUnitId,
                                                          Model.DistanceUnitTypeList) %>
                        <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.StartingDistanceUnitId)%>
                    </div>
            
                    <div class="editor-label">
                        <%= Html.LabelFor(model => model.WorkoutRegimen.FinishingNumDistanceUnits)%>
                    </div>
                    <div class="editor-field">
                        <%= Html.TextBoxFor(model => model.WorkoutRegimen.FinishingNumDistanceUnits, String.Format("{0:F}", Model.WorkoutRegimen.FinishingNumDistanceUnits))%>
                        <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.FinishingNumDistanceUnits)%>

                        <%= Html.DropDownListFor(model => model.WorkoutRegimen.FinishingDistanceUnitId,
                                                          Model.DistanceUnitTypeList) %>
                        <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.FinishingDistanceUnitId)%>
                    </div>
            
                <% } %>

                <% var timeUnitAttr = new { maxlength = 5, size = 10 }; %>

                <div class="editor-label">
                    <%= Html.LabelFor(model => model.WorkoutRegimen.StartingTotalSeconds) %>
                </div>
                <div class="editor-field">
                    <%= Html.TextBoxFor(model => model.WorkoutRegimen.StartingMinutes, timeUnitAttr) %>
                    <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.StartingMinutes) %>
                    minutes, 
                    <%= Html.TextBoxFor(model => model.WorkoutRegimen.StartingSeconds, timeUnitAttr) %>
                    <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.StartingSeconds) %>
                    seconds
                </div>
            
                <div class="editor-label">
                    <%= Html.LabelFor(model => model.WorkoutRegimen.FinishingTotalSeconds ) %>
                </div>
                <div class="editor-field">
                    <%= Html.TextBoxFor(model => model.WorkoutRegimen.FinishingMinutes, timeUnitAttr) %>
                    <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.FinishingMinutes) %>
                    minutes, 
                    <%= Html.TextBoxFor(model => model.WorkoutRegimen.FinishingSeconds, timeUnitAttr) %>
                    <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.FinishingSeconds) %>
                    seconds
                </div>
            
            <% } %>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

<% } %>
