<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%: ((webcsm.WebcsmIdentity)Page.User.Identity).Email %></b>
        [ <%: Html.ActionLink("Log Off", "LogOff", "Account") %> ]
<%
    }
    else {
%> 
        You are not logged on! Please log on. [ <%: Html.ActionLink("Log On", "LogOn", "Account") %> ]
<%
    }
%>
