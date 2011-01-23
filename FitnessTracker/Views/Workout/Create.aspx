<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FitnessTracker.Models.WorkoutViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% Html.RenderPartial("WorkoutForm"); %>

<div>
    <%= Html.ActionLink("Back to List", "Index", new { workoutRegimenId = Model.Workout.WorkoutRegimenId }) %>
</div>

</asp:Content>

