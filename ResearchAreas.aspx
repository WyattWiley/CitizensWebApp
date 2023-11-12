<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ResearchAreas.aspx.cs" Inherits="CitizensWebApp.ResearchAreas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Repeater ID="ResearchAreasRepeater" runat="server">
            <ItemTemplate>
                <a href='Projects.aspx?RA=<%# Eval("ResearchID") %>'>
                    <%# Eval("ResearchName") %>
                </a>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
