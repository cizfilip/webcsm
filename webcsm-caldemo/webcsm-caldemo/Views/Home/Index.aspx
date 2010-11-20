<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<webcsm_caldemo.ViewModels.GoogleCalendarViewModel>" %>
<%@ Import namespace="webcsm_caldemo.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Calendars for <%: Model.UserName %></h2>

    <ul>
    <% foreach (webcsm_caldemo.Models.Calendar calendar in Model.UserCalendars) { %>
        <li>
           <%:  
               Html.ActionLink(calendar.Title, "Events", "Home", new { calendar = calendar.Title, feed = calendar.CalendarID }, "")
               %>
        </li>
    <% } %>
    </ul>

</asp:Content>
