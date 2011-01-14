<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FitnessTracker.Models.WorkoutRegimenFormViewModel>" %>
<%@ Import Namespace="System.Linq" %> 
<%@ Import Namespace="FitnessTracker.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <% Html.RenderPartial("WorkoutRegimenDisplay"); %>

    <p>
        <%= Html.ActionLink("Edit Workout Regimen", "Edit", new { id=Model.WorkoutRegimen.WorkoutRegimenId }) %> |
        <%= Html.ActionLink("Back to Regimen List", "Index")%>
    </p>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Starting Time
            </th>
            <th>
                # of Miles
            </th>
            <th>
                Duration (seconds)
            </th>
        </tr>

    <% foreach (Workout workout in Model.WorkoutRegimen.Workouts.ToList())
       { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", "Workout", new { id = workout.WorkoutId, workoutRegimenId = workout.WorkoutRegimenId }, null)%> |
                <%= Html.ActionLink("Details", "Details", "Workout", new { id = workout.WorkoutId, workoutRegimenId = workout.WorkoutRegimenId }, null)%> |
                <%= Html.ActionLink("Delete", "Delete", "Workout", new { id = workout.WorkoutId, workoutRegimenId = workout.WorkoutRegimenId }, null)%>
            </td>
            <td>
                <%= Html.Encode(workout.WorkoutId)%>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", workout.StartingTime))%>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", workout.NumMiles))%>
            </td>
            <td>
                <%= Html.Encode(workout.TotalSeconds)%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New Workout", "Create", "Workout", new { workoutRegimenId = Model.WorkoutRegimen.WorkoutRegimenId }, null)%> 
    </p>


</asp:Content>

