<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<webcsm.Models.Group>" %>
 <% Html.EnableClientValidation();%>
 <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(false) %>

        <fieldset>
            <legend>Create project group</legend>
                        
            <div>
                <%: Html.LabelFor(model => model.Name) %>
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>