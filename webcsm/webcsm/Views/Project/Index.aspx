<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<webcsm.Models.Group>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <%= Html.Css("accordion.css", ResourcesHelper.CssMedia.Screen)%>
    <%= Html.Script("accordion.js")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="accordion">
        <% foreach (var item in Model)
           { %>
        <div class="accordionButton">
            <%: item.Name %>
        </div>
        <div class="accordionContent">
            <ul>
                <% foreach (var project in item.Projects)
                   { %>
                <li>
                    <%: project.Name %>
                </li>
                <% } %>
            </ul>
        </div>
        <% } %>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="NavigationContent" runat="server">
    <div id="menu-nav">
        <ul>
            <li><a href="<%: Url.Action("CreateGroup", "Project") %>">
                <img alt="Create project group" height="16" src="../../Content/images/addprojectgroup.png"
                    width="16" />Add project group</a></li>
        </ul>
        <ul>
            <li><a href="<%: Url.Action("Create", "Project") %>">
                <img alt="Create project" height="16" src="../../Content/images/addproject.png" width="16" />Add
                project</a></li>
        </ul>
    </div>
</asp:Content>
