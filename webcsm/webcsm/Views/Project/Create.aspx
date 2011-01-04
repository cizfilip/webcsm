<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<webcsm.Models.ProjectFormViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <%= Html.Css("themes/base/jquery.ui.all.css", ResourcesHelper.CssMedia.Screen)%>
    <%= Html.Script("jquery-ui-1.8.custom.min.js")%>
    <%= Html.Script("jquery.validate.min.js")%>
    <%= Html.Script("MicrosoftMvcJQueryValidation.js")%>
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation();%>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(false) %>
            <fieldset>
        <legend>Create project</legend>
        <div>
            <%: Html.LabelFor(model => model.Project.Name) %>
            <%: Html.TextBoxFor(m=>m.Project.Name)%>
            <%: Html.ValidationMessageFor(m=>m.Project.Name) %>
        </div>
        <div>
            <%: Html.LabelFor(model => model.Project.Description)%>
            <%: Html.TextBoxFor(m=>m.Project.Description)%>
            <%: Html.ValidationMessageFor(m=>m.Project.Description,"*") %>
        </div>
        <div>
            <%: Html.LabelFor(model => model.UserGroups)%>
            <%: Html.DropDownListFor(m=>m.Project.GroupId, Model.UserGroups,"Select Group") %>   
            <%: Html.ValidationMessageFor(m=>m.Project.GroupId) %>
            <button type="button" id="addGroup">Add Group</button>
        </div>
        
        <div id="hidden">
            <% Html.RenderPartial("GroupUserControl", new webcsm.Models.Group()); %>
        </div>

        <div id="users">
            <%: Html.LabelFor(model => model.Project.Users)%><p>Enter user's Emails: 
            <input type="text" id="usersList" name="usersList" /></p>
            <br />
        
        </div>

        
        
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to Projects", "Index") %>
    </div>

    
      <script type="text/javascript" language="javascript">
          $(function () {

              // add group
              $("#addGroup").click(function () {
                  $("#hidden").toggle();
              });
          });
 
      
    </script>

   <script type="text/javascript" language="javascript">
       var noOfUsers = 0;
       var user = '';
       $(function () {
           

            // users search
           function split(val) {
               return val.split(/,\s*/);
           }
           function extractLast(term) {
               return split(term).pop();
           }

           $("#usersList")
           // don't navigate away from the field on tab when selecting an item
			.bind("keydown", function (event) {
			    if (event.keyCode === $.ui.keyCode.TAB &&
						$(this).data("autocomplete").menu.active) {
			        event.preventDefault();
			    }
			})
			.autocomplete({
			    source: function (request, response) {
			        $.getJSON("/project/findusers", {
			            searchText: extractLast(request.term)
			        }, response);
			    },
			    search: function () {
			        // custom minLength
			        var term = extractLast(this.value);
			        if (term.length < 2) {
			            return false;
			        }
			    },
			    focus: function () {
			        // prevent value inserted on focus
			        return false;
			    },
			    select: function (event, ui) {
			        var terms = split(this.value);
			        // remove the current input
			        terms.pop();
			        // add the selected item
			        terms.push(ui.item.value);
			        // add placeholder to get the comma-and-space at the end
			        terms.push("");
			        this.value = terms.join(", ");
			        return false;
			    }
			});

       });

       
    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="NavigationContent" runat="server">
</asp:Content>
