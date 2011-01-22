<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FitnessTracker.Models.WorkoutViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>

    <% Html.RenderPartial("WorkoutDisplay"); %>
    
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%= Html.ActionLink("Back to List", "Index", new { workoutRegimenId = Model.Workout.WorkoutRegimenId })%>
        </p>
    <% } %>

</asp:Content>

