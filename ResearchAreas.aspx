<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ResearchAreas.aspx.cs" Inherits="CitizensWebApp.ResearchAreas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="institution-list">
        <h2 class="institution-title">Research Areas</h2>
        <table class="institution-table">
            <asp:Repeater ID="ResearchAreasRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a class="institution-link" href='Projects.aspx?RA=<%# Eval("ResearchID") %>'>
                                <%# Eval("ResearchName") %>
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
