<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MyReports.aspx.cs" Inherits="CitizensWebApp.MyReports" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>My Reports</h2>
    <asp:GridView ID="gvReports" CssClass="report-table" runat="server" AutoGenerateColumns="False" OnRowEditing="gvReports_RowEditing" OnRowUpdating="gvReports_RowUpdating" OnRowCancelingEdit="gvReports_RowCancelingEdit" OnRowDeleting="gvReports_RowDeleting" 
    DataKeyNames="ObservationID">
        <Columns>
            <asp:BoundField DataField="ObservationID" HeaderText="Observation ID" ItemStyle-Width="13%" />
            <asp:BoundField DataField="Value" HeaderText="Value" />
            <asp:BoundField DataField="ObservedDate" HeaderText="Observed Date" ItemStyle-Width="18%" />
            <asp:BoundField DataField="Notes" HeaderText="Notes" />
            <asp:BoundField DataField="ToolID" HeaderText="ToolID" />
            <asp:BoundField DataField="Latitude" HeaderText="Latitude" />
            <asp:BoundField DataField="Longitude" HeaderText="Longitude" />
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>