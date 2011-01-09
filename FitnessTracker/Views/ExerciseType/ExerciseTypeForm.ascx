<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FitnessTracker.Models.ExerciseType>" %>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Name) %>
                <%= Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.IsDistanceUsed) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.IsDistanceUsed)%>
                <%= Html.ValidationMessageFor(model => model.IsDistanceUsed) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.MinSecondsPerMile) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.MinSecondsPerMile) %>
                <%= Html.ValidationMessageFor(model => model.MinSecondsPerMile) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.MaxSecondsPerMile) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.MaxSecondsPerMile) %>
                <%= Html.ValidationMessageFor(model => model.MaxSecondsPerMile) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>
