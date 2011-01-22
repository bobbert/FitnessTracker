<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FitnessTracker.Models.WorkoutViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <% Html.RenderPartial("WorkoutDisplay"); %>

    <p>
        <%= Html.ActionLink("Edit", "Edit", new { workoutRegimenId = Model.Workout.WorkoutRegimenId,
                                                  id = Model.Workout.WorkoutId })%> |
        <%= Html.ActionLink("Back to List", "Index", new { workoutRegimenId = Model.Workout.WorkoutRegimenId } )%>
    </p>

</asp:Content>

