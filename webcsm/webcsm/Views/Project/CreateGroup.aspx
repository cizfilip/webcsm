<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<webcsm.Models.Group>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create Group
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <% Html.RenderPartial("GroupUserControl"); %>

    <div>
        <%: Html.ActionLink("Back to Projects", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
<%= Html.Script("jquery.validate.min.js")%>
<%= Html.Script("MicrosoftMvcJQueryValidation.js")%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="NavigationContent" runat="server">

</asp:Content>

