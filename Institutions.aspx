<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Institutions.aspx.cs" Inherits="CitizensWebApp.Institutions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="institution-list">
        <h2 class="institution-title">Institutions</h2>
        <table class="institution-table">
            <asp:Repeater ID="InstitutionsRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a class="institution-link" href='ResearchAreas.aspx?InstID=<%# Eval("InstitutionID") %>'>
                                <%# Eval("InstitutionName") %>
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>


