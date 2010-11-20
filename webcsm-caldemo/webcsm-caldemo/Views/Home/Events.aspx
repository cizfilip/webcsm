<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<webcsm_caldemo.ViewModels.GoogleCalendarEventsViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Events
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Events in <%: Model.CalendarName %></h2>

    <table>
 
        <tr>
            <th>Title</th>
            <th>Summary</th>
            <th>Start time</th>
            <th>End time</th>
        </tr>
 
        <% foreach (var item in Model.Events) { %>
        <tr>
            <td>
                <%: item.Title %>
            </td>
            <td>
                <%: item.Summary %>
            </td>
            <td>
                <%: item.StartTime %>
            </td>
            <td>
                <%: item.EndTime %>
            </td>
        </tr>
        <% } %>
  
    </table>

</asp:Content>
