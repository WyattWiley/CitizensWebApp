<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Register.aspx.cs" Inherits="CitizensWebApp.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<main>
    <div>
        <h4 style="font-size: medium">Register as a New Volunteer</h4>
    <hr />
        <p>
            <asp:Literal runat="server" ID="StatusMessage" />
        </p>
    <div style="margin-bottom:10px">
        <asp:Label runat="server" AssociatedControlID="FullName">Full Name</asp:Label>
    <div>
    <asp:TextBox runat="server" ID="FullName" />
    </div>
    </div>
    <div style="margin-bottom:10px">
        <asp:Label runat="server" AssociatedControlID="Email">Email</asp:Label>
    <div>
    <asp:TextBox runat="server" ID="Email" />
    </div>
    </div>
    <div style="margin-bottom:10px">
    <asp:Label runat="server" AssociatedControlID="ContactNumber">Contact Number</asp:Label>
        <div>
                <asp:TextBox runat="server" ID="ContactNumber" />
            </div>
        </div>
        <div style="margin-bottom:10px">
            <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />                
            </div>
        </div>
        <div style="margin-bottom:10px">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />                
            </div>
        </div>
        <div>
            <div>
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn" />
            </div>
        </div>
    </div>
        </main>
</asp:Content>
