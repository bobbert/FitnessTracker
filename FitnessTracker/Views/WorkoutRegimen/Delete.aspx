<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FitnessTracker.Models.WorkoutRegimenFormViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">WorkoutRegimenId</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.WorkoutRegimenId) %></div>
        
        <div class="display-label">FitnessUserId</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.FitnessUserId) %></div>
        
        <div class="display-label">ExerciseTypeId</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.ExerciseTypeId) %></div>
        
        <div class="display-label">StartDate</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:g}", Model.WorkoutRegimen.StartDate)) %></div>
        
        <div class="display-label">NumWeeks</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.NumWeeks) %></div>
        
        <div class="display-label">DaysPerWeek</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.DaysPerWeek) %></div>
        
        <div class="display-label">StartingPace</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:F}", Model.WorkoutRegimen.StartingPace)) %></div>
        
        <div class="display-label">FinishingPace</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:F}", Model.WorkoutRegimen.FinishingPace)) %></div>
        
        <div class="display-label">StartingDuration</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.StartingDuration) %></div>
        
        <div class="display-label">FinishingDuration</div>
        <div class="display-field"><%= Html.Encode(Model.WorkoutRegimen.FinishingDuration) %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%= Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>

</asp:Content>

