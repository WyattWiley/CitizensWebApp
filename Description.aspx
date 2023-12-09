<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Description.aspx.cs" Inherits="CitizensWebApp.Description" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Welcome to The Citizen Science Website</h1>
    <p>
        This is a website that allows logged in volunteers to see institutions along with institutions research areas and the projects within the research areas. You will also be able to see the details of each project. 
        If volunteers are logged in, they will be allowed to add observations to project details page for specific projects. 
        We also have a feature that allows volunteers to enter feedback on our website. Please give suggestion on what you like and dislike about the website. This feedback will be reviewed and taken into consideration by our administrators!
    </p>
    <asp:Button ID="btnFeedback" runat="server" Text="Give Feedback" OnClick="btnFeedback_Click" />
</asp:Content>
