<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FitnessTracker.Models.ExerciseTypeViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <% Html.RenderPartial("ExerciseTypeDisplay"); %>

    <p>
        <% if (User.IsInRole("admin")) { %>
            <%= Html.ActionLink("Edit", "Edit", new { id = Model.ExerciseType.ExerciseTypeId })%> |
        <% } %>
        <%= Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

