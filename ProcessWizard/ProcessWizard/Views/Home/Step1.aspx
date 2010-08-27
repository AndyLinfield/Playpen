<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProcessWizard.Controllers.EmailDto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%= Html.ValidationSummary() %>

    <form method="post">
        <label for="EmailAddress">Email Address:</label>
        <input type="text" name="EmailAddress" value="<%= Model.EmailAddress %>" />
        <input type="submit" />
    </form>

</asp:Content>
