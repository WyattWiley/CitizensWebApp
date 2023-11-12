<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Institutions.aspx.cs" Inherits="CitizensWebApp.Institutions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Repeater ID="InstitutionsRepeater" runat="server">
            <ItemTemplate>
                <a href='ResearchAreas.aspx?InstID=<%# Eval("InstitutionID") %>'>
                    <%# Eval("InstitutionName") %>
                </a>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>


