<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FitnessTracker.Models.WorkoutRegimenFormViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

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
                <%= Html.TextBoxFor(model => model.WorkoutRegimen.StartDate) %>
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
                <%= Html.LabelFor(model => model.WorkoutRegimen.StartingPace) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.WorkoutRegimen.StartingPace) %>
                <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.StartingPace) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.WorkoutRegimen.FinishingPace) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.WorkoutRegimen.FinishingPace) %>
                <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.FinishingPace) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.WorkoutRegimen.StartingDuration) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.WorkoutRegimen.StartingDuration) %>
                <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.StartingDuration) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.WorkoutRegimen.FinishingDuration) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.WorkoutRegimen.FinishingDuration) %>
                <%= Html.ValidationMessageFor(model => model.WorkoutRegimen.FinishingDuration) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

