<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Feedback.aspx.cs" Inherits="CitizensWebApp.Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Give Your Feedback</h1>
    <p>
        <asp:Label ID="lblFeedback" runat="server" Text="Your Feedback:" AssociatedControlID="txtFeedback"></asp:Label>
        <asp:TextBox ID="txtFeedback" runat="server" TextMode="MultiLine"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Feedback" OnClick="btnSubmit_Click" />
    </p>
    <asp:Label ID="lblMessage" runat="server" Text="" Visible="false"></asp:Label>
</asp:Content>