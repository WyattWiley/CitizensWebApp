<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProjectDetails.aspx.cs" Inherits="CitizensWebApp.ProjectDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="institution-list">
        <h2 class="institution-title">Project Details</h2>
        <table class="institution-table">
            <asp:Repeater ID="ProjectDetailsRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <div class="project-link">
                                <strong>Project ID:</strong> <%# Eval("ProjectID") %> <br />
                                <strong>Report ID:</strong> <%# Eval("ReportID") %> <br />
                                <strong>Project Name:</strong> <%# Eval("ProjectName") %> <br />
                                <strong>Start Date:</strong> <%# Eval("StartDate") %> <br />
                                <strong>End Date:</strong> <%# Eval("EndDate") %> <br />
                                <strong>Description:</strong> <%# Eval("Description") %> <br />
                                <strong>Observation ID:</strong> <%# Eval("ObservationID") %> <br />
                                <strong>Value:</strong> <%# Eval("Value") %> <br />
                                <strong>Observed Date:</strong> <%# Eval("ObservedDate") %> <br />
                                <strong>Notes:</strong> <%# Eval("Notes") %> <br />
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <asp:Button ID="btnAddObservation" runat="server" Text="Add Observation" OnClick="btnAddObservation_Click" Visible='<%# HttpContext.Current.User.Identity.IsAuthenticated %>'/>
    </div>
</asp:Content>
