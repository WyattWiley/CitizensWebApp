<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProjectDetails.aspx.cs" Inherits="CitizensWebApp.ProjectDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Repeater ID="ProjectDetailsRepeater" runat="server">
            <ItemTemplate>
                <strong>Project ID:</strong> <%# Eval("ProjectID") %> <br />
                <strong>Project Name:</strong> <%# Eval("ProjectName") %> <br />
                <strong>Start Date:</strong> <%# Eval("StartDate") %> <br />
                <strong>End Date:</strong> <%# Eval("EndDate") %> <br />
                <strong>Description:</strong> <%# Eval("Description") %> <br />
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
