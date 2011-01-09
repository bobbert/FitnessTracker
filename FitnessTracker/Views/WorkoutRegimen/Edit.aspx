<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FitnessTracker.Models.WorkoutRegimenFormViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% Html.RenderPartial("WorkoutRegimenForm"); %>

<div>
    <%= Html.ActionLink("Details", "Index", "Workout", new { workoutRegimenId = Model.WorkoutRegimen.WorkoutRegimenId }, null)%> |
    <%= Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>

