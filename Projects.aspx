<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Projects.aspx.cs" Inherits="CitizensWebApp.Projects" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="institution-list">
        <h2 class="institution-title">Projects</h2>
        <table class="institution-table">
            <asp:Repeater ID="ProjectsRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a class="institution-link" href='ProjectDetails.aspx?ProjectID=<%# Eval("ProjectID") %>'>
                                <%# Eval("ProjectName") %>
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
