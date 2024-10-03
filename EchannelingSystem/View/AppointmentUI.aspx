<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="AppointmentUI.aspx.cs" Inherits="EchannelingSystem.View.AppointmentUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bg-light p-5 my-5 border col-sm-8">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="AppCalendarSearchUI.aspx">Search for Appointments</a></li>
                <li class="breadcrumb-item active" aria-current="page"><b>Book Appointment</b></li>
            </ol>
        </nav>

        <div class="row mb-3">
            <asp:Label ID="Label2" runat="server" Text="Label" class="col-sm-4 col-form-label">Consultant Name</asp:Label>
            <asp:TextBox ID="txtConsultantName" runat="server" class="form-control" Enabled="false"></asp:TextBox>
            <asp:HiddenField ID="hdnConsultantid" runat="server" />
        </div>
        <div class="row mb-3">
            <div class="col-sm">
                <asp:Label ID="Label5" runat="server" Text="Label" class="col-sm-4 col-form-label">Date</asp:Label><br />
                <asp:TextBox ID="ddlDateAvailable" class="form-control" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label1" runat="server" Text="Label" class="col-sm-4 col-form-label">From</asp:Label><br />
                <asp:TextBox ID="txtFrom" class="form-control" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label3" runat="server" Text="Label" class="col-sm-4 col-form-label">To</asp:Label><br />
                <asp:TextBox ID="txtTo" class="form-control" runat="server" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-sm">
                <asp:Label ID="Label7" runat="server" Text="Label" class="col-sm-4 col-form-label">Booked Appointments</asp:Label>
                <asp:TextBox ID="txtBalance" runat="server" class="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label15" runat="server" Text="Label" class="col-sm-4 col-form-label">Branch</asp:Label><br />
                <asp:TextBox ID="txtBranch" runat="server" class="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label12" runat="server" Text="Label" class="col-sm-4 col-form-label">Consultation Fee</asp:Label>
                <div class="input-group mb-2">
                    <div class="input-group-prepend">
                        <div class="input-group-text">Rs.</div>
                    </div>
                    <asp:TextBox ID="txtConsultationFee" runat="server" class="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <asp:HiddenField ID="hdnAppCalendarId" runat="server" />
        </div>
        <div class="d-grid gap-2 d-md-flex justify-content-md-end">
            <asp:Button ID="btnBook" runat="server" class="btn btn-primary" Text="Book Appointment" OnClick="btnBook_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-secondary" OnClientClick="window.history.go(-1); return false;" />
        </div>
    </div>
</asp:Content>


