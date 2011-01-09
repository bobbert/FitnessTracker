<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<FitnessTracker.Models.WorkoutFormViewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                WorkoutId
            </th>
            <th>
                WorkoutRegimenId
            </th>
            <th>
                Date
            </th>
            <th>
                Pace
            </th>
            <th>
                Duration
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.Workout.WorkoutId }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.Workout.WorkoutId })%> |
                <%= Html.ActionLink("Delete", "Delete", new { id=item.Workout.WorkoutId })%>
            </td>
            <td>
                <%= Html.Encode(item.Workout.WorkoutId) %>
            </td>
            <td>
                <%= Html.Encode(item.Workout.WorkoutRegimenId) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.Workout.Date)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.Workout.Pace)) %>
            </td>
            <td>
                <%= Html.Encode(item.Workout.Duration) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %> |
        <%= Html.ActionLink("Back to Workout Regimens", "Index", "WorkoutRegimen") %>
    </p>

</asp:Content>

