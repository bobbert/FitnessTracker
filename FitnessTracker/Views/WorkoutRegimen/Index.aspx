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
                Exercise Type
            </th>
            <th>
                StartDate
            </th>
            <th>
                NumWeeks
            </th>
            <th>
                Days Per Week
            </th>
            <th>
                Starting Pace
            </th>
            <th>
                Finishing Pace
            </th>
            <th>
                Starting Duration
            </th>
            <th>
                Finishing Duration
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.WorkoutRegimen.WorkoutRegimenId }) %> |
                <%= Html.ActionLink("Details", "Index", "Workout", new { workoutRegimenId = item.WorkoutRegimen.WorkoutRegimenId }, null)%> |
                <%= Html.ActionLink("Delete", "Delete", new { id=item.WorkoutRegimen.WorkoutRegimenId })%>
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
                <%= Html.Encode(String.Format("{0:F}", item.WorkoutRegimen.StartingPace)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.WorkoutRegimen.FinishingPace)) %>
            </td>
            <td>
                <%= Html.Encode(item.WorkoutRegimen.StartingDuration) %>
            </td>
            <td>
                <%= Html.Encode(item.WorkoutRegimen.FinishingDuration) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

