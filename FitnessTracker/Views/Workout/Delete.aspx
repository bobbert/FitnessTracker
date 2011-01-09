<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FitnessTracker.Models.WorkoutFormViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">WorkoutId</div>
        <div class="display-field"><%= Html.Encode(Model.Workout.WorkoutId) %></div>
        
        <div class="display-label">WorkoutRegimenId</div>
        <div class="display-field"><%= Html.Encode(Model.Workout.WorkoutRegimenId) %></div>
        
        <div class="display-label">Date</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:g}", Model.Workout.Date)) %></div>
        
        <div class="display-label">Pace</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:F}", Model.Workout.Pace)) %></div>
        
        <div class="display-label">Duration</div>
        <div class="display-field"><%= Html.Encode(Model.Workout.Duration) %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%= Html.ActionLink("Back to List", "Index", new { workoutRegimenId = Model.Workout.WorkoutRegimenId })%>
        </p>
    <% } %>

</asp:Content>

