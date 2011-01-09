<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FitnessTracker.Models.WorkoutRegimenFormViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <% Html.RenderPartial("WorkoutRegimenDisplay"); %>

    <p>
        <%= Html.ActionLink("View Workouts", "Index", "Workout", new { workoutRegimenId = Model.WorkoutRegimen.WorkoutRegimenId }, null)%> |
        <%= Html.ActionLink("Edit", "Edit", new { id=Model.WorkoutRegimen.WorkoutRegimenId }) %> |
        <%= Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

