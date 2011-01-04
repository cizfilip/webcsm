<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<webcsm.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>
<asp:Content ID="loginHeader" ContentPlaceHolderID="HeadContent" runat="server">
    <%= Html.Script("openIdUrl.js")%>
    
</asp:Content>
<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <%: Html.ValidationSummary(true, "Login was unsuccessful. Please correct the errors and try again.") %>
    <div class="loginbox">
        Login using <strong>Google</strong> account (Recommended):
        <% using (Html.BeginForm(new { Controller = "Account", Action = "GoogleLogOn" }))
           { %>
        <fieldset>
            <legend>Google login</legend>
            <div>
                <input id="openid_identifier" name="openid_identifier" type="hidden" />
                <img id="googlelogon" alt="Log On via Google account" onclick="openIdUrl('google')"
                    src="../../Content/images/google_logo.jpg" title="Google" />
                <input id="btnGoogleLogin" type="submit" value="Log On" />
            </div>
        </fieldset>
        <% } %>
    </div>
    <div class="loginbox">
        Login using <strong>Webcsm</strong> account:
        <% using (Html.BeginForm())
           { %>
        <p>
            Please complete the form below.</p>
        <fieldset class="login">
            <legend>Webcsm login</legend>
            <div>
                <%: Html.LabelFor(m => m.UserName) %>
                <%: Html.TextBoxFor(m => m.UserName) %>
                <%: Html.ValidationMessageFor(m => m.UserName) %>
            </div>
            <div>
                <%: Html.LabelFor(m => m.Password) %>
                <%: Html.PasswordFor(m => m.Password) %>
                <%: Html.ValidationMessageFor(m => m.Password) %>
            </div>
            <div>
                <%: Html.LabelFor(m => m.RememberMe) %>
                <%: Html.CheckBoxFor(m => m.RememberMe) %>
            </div>
            <p>
                <input type="submit" value="Log On" />
            </p>
        </fieldset>
        <% } %>
    </div>
    <div id="blank">
    </div>
</asp:Content>
<asp:Content ID="loginNavigation" ContentPlaceHolderID="NavigationContent" runat="server">
    <div id="menu-nav">
        <ul>
            <li><a href="<%: Url.Action("Register", "Account") %>">
                <img alt="Register" height="16" src="../../Content/images/register.png" width="16" />Register</a></li>
        </ul>
    </div>
</asp:Content>
