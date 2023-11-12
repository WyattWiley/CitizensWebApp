<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Projects.aspx.cs" Inherits="CitizensWebApp.Projects" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Repeater ID="ProjectsRepeater" runat="server">
            <ItemTemplate>
                <a href='ProjectDetails.aspx?ProjectID=<%# Eval("ProjectID") %>'>
                    <%# Eval("ProjectName") %>
                </a>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
