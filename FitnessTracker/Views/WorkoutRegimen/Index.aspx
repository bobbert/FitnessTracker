<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<FitnessTracker.Models.WorkoutRegimenFormViewModel>>" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Exercise Type
            </th>
            <th>
                Starting Date
            </th>
            <th>
                # of Weeks
            </th>
            <th>
                Days per Week
            </th>
            <th>
                Starting # of Miles
            </th>
            <th>
                Finishing # of Miles
            </th>
            <th>
                Starting Duration (seconds)
            </th>
            <th>
                Finishing Duration (seconds)
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.WorkoutRegimen.WorkoutRegimenId }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.WorkoutRegimen.WorkoutRegimenId })%> |
                <%= Html.ActionLink("Delete", "Delete", new { id=item.WorkoutRegimen.WorkoutRegimenId })%>
            </td>
            <td>
                <%= Html.Encode(item.WorkoutRegimen.WorkoutRegimenId) %>
            </td>
            <td>
                <%= Html.Encode(item.GetExerciseTypeName()) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.WorkoutRegimen.StartDate)) %>
            </td>
            <td>
                <%= Html.Encode(item.WorkoutRegimen.NumWeeks) %>
            </td>
            <td>
                <%= Html.Encode(item.WorkoutRegimen.DaysPerWeek) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.WorkoutRegimen.StartingNumMiles)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.WorkoutRegimen.FinishingNumMiles)) %>
            </td>
            <td>
                <%= Html.Encode(item.WorkoutRegimen.StartingTotalSeconds) %>
            </td>
            <td>
                <%= Html.Encode(item.WorkoutRegimen.FinishingTotalSeconds) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

