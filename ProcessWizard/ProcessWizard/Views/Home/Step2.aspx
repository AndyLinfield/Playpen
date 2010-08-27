<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProcessWizard.Controllers.FirstNameDto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form method="post">
        <label for="FirstName">First Name:</label>
        <input type="text" name="FirstName" value="<%= Model.FirstName %>" />
        <label for="Initial">Initial:</label>
        <input type="text" name="Initial" value="<%= Model.Initial %>" />
        <input type="submit" />
    </form>

</asp:Content>
