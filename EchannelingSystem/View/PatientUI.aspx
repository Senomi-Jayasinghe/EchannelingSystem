<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="PatientUI.aspx.cs" Inherits="EchannelingSystem.View.PatientUI1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container bg-light p-5 my-5 border col-sm-8">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="HomeUI.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page"><b>Patient</b></li>
            </ol>
        </nav>
        <div class="row">
            <div class="col-sm">
                <asp:Label ID="Label1" runat="server" Text="Label" class="col-sm-4 col-form-label">Title</asp:Label>
                <asp:DropDownList ID="ddlTitle" runat="server" class="form-control" required></asp:DropDownList>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label2" runat="server" Text="Label" class="col-sm-4 col-form-label">Initial</asp:Label>
                <asp:TextBox ID="txtInitial" runat="server" class="form-control" required></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm">
                <asp:Label ID="Label3" runat="server" Text="Label" class="col-sm-4 col-form-label">Last Name</asp:Label>
                <asp:TextBox ID="txtLastName" runat="server" class="form-control" AutoPostBack="True" OnTextChanged="txtInitial_TextChanged" required></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label4" runat="server" Text="Label" class="col-sm-4 col-form-label">Full Name</asp:Label>
                <asp:TextBox ID="txtFullName" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-sm">
                <asp:Label ID="Label5" runat="server" Text="Label" class="col-sm-4 col-form-label">Date of Birth</asp:Label>
                <asp:TextBox ID="ddlDateOfBirth" class="form-control" data-provide="datepicker" runat="server" required></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label6" runat="server" Text="Label" class="col-sm-4 col-form-label">Gender</asp:Label>

                <asp:DropDownList ID="ddlGender" runat="server" class="form-control" required>
                    <asp:ListItem Text="Select" Value="0" />
                    <asp:ListItem Text="Female" Value="Female" />
                    <asp:ListItem Text="Male" Value="Male" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-sm">
                <asp:Label ID="Label7" runat="server" Text="Label" class="col-sm-4 col-form-label">NIC</asp:Label>
                <asp:TextBox ID="txtNIC" type="number" runat="server" class="form-control" required></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label8" runat="server" Text="Label" class="col-sm-4 col-form-label">Passport</asp:Label>
                <asp:TextBox ID="txtPassport" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm">
                <asp:Label ID="Label9" runat="server" Text="Label" class="col-sm-4 col-form-label">Address</asp:Label>
                <textarea id="txtAddress" runat="server" cols="20" rows="2" class="form-control" required></textarea>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label10" runat="server" Text="Label" class="col-sm-4 col-form-label">District</asp:Label>
                <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-sm">
                <asp:Label ID="Label11" runat="server" Text="Label" class="col-sm-4 col-form-label">Email Address</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" type="email" class="form-control" required></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label12" runat="server" Text="Label" class="col-sm-4 col-form-label">Mobile Number</asp:Label>
                <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" pattern="^0\d{9}$" title="Please enter a phone number starting with '0' followed by nine digits." required></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label13" runat="server" Text="Label" class="col-sm-4 col-form-label">Telephone Number</asp:Label>
                <asp:TextBox ID="txtTelephoneNo" runat="server" class="form-control" pattern="^0\d{9}$" title="Please enter a phone number starting with '0' followed by nine digits."></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm">
                <asp:Label ID="Label14" runat="server" Text="Label" class="col-sm-4 col-form-label">Geo Location</asp:Label>
                <asp:TextBox ID="txtGeoLocation" runat="server" class="form-control" required></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label15" runat="server" Text="Label" class="col-sm-4 col-form-label">Branch</asp:Label>
                <asp:DropDownList ID="ddlBranch" runat="server" class="form-control"></asp:DropDownList>
            </div>
        </div>
        <br />

        <asp:Panel ID="pnlMsg" runat="server" Visible="false">
            <asp:Label ID="lblPnlMsg" runat="server" Text="Label"></asp:Label>
        </asp:Panel>

        <div class="d-grid gap-2 d-md-flex justify-content-md-end">
            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" OnClick="btnSave_Click" Text="Save" />
            <asp:Button ID="btnReset" runat="server" class="btn btn-secondary" OnClick="btnReset_Click" Text="Reset" formnovalidate="formnovalidate"/>
            <asp:HiddenField ID="hdnPatientId" runat="server" />
            <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-secondary" OnClientClick="window.history.go(-1); return false;" Visible="false" />
        </div>
    </div>
</asp:Content>
