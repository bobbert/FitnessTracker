<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FitnessTracker.Models.WorkoutFormViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Workout.Date) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Workout.Date, String.Format("{0:g}", Model.Workout.Date))%>
                <%= Html.ValidationMessageFor(model => model.Workout.Date) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Workout.Pace) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Workout.Pace, String.Format("{0:F}", Model.Workout.Pace))%>
                <%= Html.ValidationMessageFor(model => model.Workout.Pace) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Workout.Duration) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Workout.Duration) %>
                <%= Html.ValidationMessageFor(model => model.Workout.Duration) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "Index", new { workoutRegimenId = Model.Workout.WorkoutRegimenId })%>
    </div>

</asp:Content>

