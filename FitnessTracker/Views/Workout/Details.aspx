<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FitnessTracker.Models.WorkoutFormViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Workout Regimen</div>
        <div class="display-field"><%= Html.Encode(Model.Workout.WorkoutRegimenId) %></div>
        
        <div class="display-label">Date</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:g}", Model.Workout.Date)) %></div>
        
        <div class="display-label">Pace</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:F}", Model.Workout.Pace)) %></div>
        
        <div class="display-label">Duration</div>
        <div class="display-field"><%= Html.Encode(Model.Workout.Duration) %></div>
        
    </fieldset>
    <p>

        <%= Html.ActionLink("Edit", "Edit", new { workoutRegimenId = Model.Workout.WorkoutRegimenId,
                                                  id = Model.Workout.WorkoutId })%> |
        <%= Html.ActionLink("Back to List", "Index", new { workoutRegimenId = Model.Workout.WorkoutRegimenId } )%>
    </p>

</asp:Content>

