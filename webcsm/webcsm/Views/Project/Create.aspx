<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<webcsm.Models.Project>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
<%= Html.Script("UsersListBoxes.js")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Create project</legend>
        <div>
            <%: Html.LabelFor(model => model.Name) %>
            <%: Html.TextBoxFor(model => model.Name) %>
            <%: Html.ValidationMessageFor(model => model.Name) %>
        </div>
        <div>
            <%: Html.LabelFor(model => model.Description) %>
            <%: Html.TextBoxFor(model => model.Description) %>
            <%: Html.ValidationMessageFor(model => model.Description) %>
        </div>
        <div>
            <%: Html.Label("Groups") %>
            <br />
            <ul>
                <% foreach (var item in (IEnumerable<webcsm.Models.Group>)ViewData["Groups"])
                   { %>
                <li>
                    <input type="checkbox" name="GroupID" id="GroupID" value="<%=item.Id %>" />
                    <%= item.Name  %>
                </li>
                <% } %>
            </ul>
        </div>
        <div>
            <%: Html.Label("Users") %>
            <table border="0">
                <tr>
                    <td valign="top" align="left">
                        <%= Html.ListBox("AvailableUsers", null, new { @size = "8", @style = "width:200px" })%>
                    </td>
                    <td valign="middle" align="center">
                        <input id="btnAdd" type="button" value=" > " onclick="add();" /><br />
                        <input id="btnAddAll" type="button" value=" >> " onclick="addall();" /><br />
                        <input id="btnRemove" type="button" value=" < " onclick="remove();" /><br />
                        <input id="btnRemoveAll" type="button" value=" << " onclick="removeall();" />
                    </td>
                    <td valign="top" align="left">
                        <%= Html.ListBox("SelectedUsers", null, new { @size = "8", @style = "width:200px" })%>
                    </td>
                </tr>
            </table>
            
        </div>
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="NavigationContent" runat="server">
</asp:Content>
