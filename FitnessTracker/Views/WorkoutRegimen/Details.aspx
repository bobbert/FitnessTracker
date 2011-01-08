<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FitnessTracker.Models.WorkoutRegimenFormViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Exercise Type</div>
        <div class="display-field"><%= Html.Encode(Model.GetExerciseTypeName()) %></div>
        
        <div class="display-label">Start Date</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:g}", Model.WorkoutRegimen.StartDate)) %></div>
        
        <div class="display-label">Num Weeks</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.NumWeeks) %></div>
        
        <div class="display-label">Days Per Week</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.DaysPerWeek) %></div>
        
        <div class="display-label">Starting Pace</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:F}", Model.WorkoutRegimen.StartingPace)) %></div>
        
        <div class="display-label">Finishing Pace</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:F}", Model.WorkoutRegimen.FinishingPace)) %></div>
        
        <div class="display-label">Starting Duration</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.StartingDuration) %></div>
        
        <div class="display-label">Finishing Duration</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.FinishingDuration) %></div>
        
    </fieldset>
    <p>

        <%= Html.ActionLink("Edit", "Edit", new { id=Model.WorkoutRegimen.WorkoutRegimenId }) %> |
        <%= Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

