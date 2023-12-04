<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="NewReports.aspx.cs" Inherits="CitizensWebApp.NewReports" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
        <h2 class="form-title">Add Observation</h2>
        <asp:Label ID="lblMessage" runat="server" EnableViewState="false" />
        <div class="form-field">
            <asp:Label ID="lblReportDate" runat="server" Text="Report Date:" />
            <asp:TextBox ID="txtReportDate" runat="server" TextMode="DateTime" />
        </div>
        <div class="form-field">
            <asp:Label ID="lblValue" runat="server" Text="Value:" />
            <asp:TextBox ID="txtValue" runat="server" />
        </div>
        <div class="form-field">
            <asp:Label ID="lblObservedDate" runat="server" Text="Observed Date:" />
            <asp:TextBox ID="txtObservedDate" runat="server" TextMode="DateTime" />
        </div>
        <div class="form-field">
            <asp:Label ID="lblNotes" runat="server" Text="Notes:" />
            <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" />
        </div>
        <div class="form-field">
            <asp:Label ID="lblToolID" runat="server" Text="Tool ID:" />
            <asp:TextBox ID="txtToolID" runat="server" />
        </div>
        <div class="form-field">
            <asp:Label ID="lblLatitude" runat="server" Text="Latitude:" />
            <asp:TextBox ID="txtLatitude" runat="server" />
        </div>
        <div class="form-field">
            <asp:Label ID="lblLongitude" runat="server" Text="Longitude:" />
            <asp:TextBox ID="txtLongitude" runat="server" />
        </div>
        <div class="form-field">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>