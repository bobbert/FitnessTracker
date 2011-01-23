<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FitnessTracker.Models.ExerciseTypeViewModel>" %>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.ExerciseType.Name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.ExerciseType.Name) %>
                <%= Html.ValidationMessageFor(model => model.ExerciseType.Name) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.ExerciseType.HasDistanceData) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.HasDistanceDataSelectList,
                                         Model.HasDistanceDataSelectList) %>
                <%= Html.ValidationMessageFor(model => model.ExerciseType.HasDistanceData) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.ExerciseType.MinSecondsPerMile) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.ExerciseType.MinSecondsPerMile) %>
                <%= Html.ValidationMessageFor(model => model.ExerciseType.MinSecondsPerMile) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.ExerciseType.MaxSecondsPerMile) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.ExerciseType.MaxSecondsPerMile) %>
                <%= Html.ValidationMessageFor(model => model.ExerciseType.MaxSecondsPerMile) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>
