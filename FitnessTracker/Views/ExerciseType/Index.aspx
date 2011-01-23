<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<FitnessTracker.Models.ExerciseTypeViewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Name
            </th>
            <th>
                Distance Used?
            </th>
            <th>
                Min Seconds/Mile
            </th>
            <th>
                Max Seconds/Mile
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <% if (User.IsInRole("admin")) { %>
                    <%= Html.ActionLink("Edit", "Edit", new { id=item.ExerciseType.ExerciseTypeId }) %> |
                    <%= Html.ActionLink("Details", "Details", new { id=item.ExerciseType.ExerciseTypeId }) %> |
                    <%= Html.ActionLink("Delete", "Delete", new { id=item.ExerciseType.ExerciseTypeId }) %>
                <% } else { %>
                    <%= Html.ActionLink("Details", "Details", new { id=item.ExerciseType.ExerciseTypeId }) %>
                <% } %>
            </td>
            <td>
                <%= Html.Encode(item.ExerciseType.ExerciseTypeId) %>
            </td>
            <td>
                <%= Html.Encode(item.ExerciseType.Name) %>
            </td>
            <td>
                <%= Html.Encode(item.ExerciseType.HasDistanceData) %>
            </td>
            <td>
                <%= Html.Encode(item.ExerciseType.MinSecondsPerMile) %>
            </td>
            <td>
                <%= Html.Encode(item.ExerciseType.MaxSecondsPerMile) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <% if (User.IsInRole("admin")) { %>
    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>
    <% } %>

</asp:Content>

