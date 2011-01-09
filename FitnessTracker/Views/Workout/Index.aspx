<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<FitnessTracker.Models.WorkoutFormViewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

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

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id = item.Workout.WorkoutId }) %> |
                <%= Html.ActionLink("Details", "Details", new { id = item.Workout.WorkoutId })%> |
                <%= Html.ActionLink("Delete", "Delete", new { id = item.Workout.WorkoutId })%>
            </td>
            <td>
                <%= Html.Encode(item.Workout.WorkoutId)%>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.Workout.StartingTime))%>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.Workout.NumMiles))%>
            </td>
            <td>
                <%= Html.Encode(item.Workout.TotalSeconds)%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %> |
        <%= Html.ActionLink(String.Format("Back to Regimen #{0}", ViewData["workoutRegimenId"]), "Details", "WorkoutRegimen",
                            new { id = ViewData["workoutRegimenId"] }, null)%> |
        <%= Html.ActionLink("Back to Workout Regimens", "Index", "WorkoutRegimen") %>
    </p>

</asp:Content>

