<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="PatientSearchUI.aspx.cs" Inherits="EchannelingSystem.View.PatientSearchUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bg-light p-5 my-5 border col-sm-8">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="HomeUI.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Patient Search</li>
            </ol>
        </nav>
        <h1>
            <asp:Label ID="lblHeader" runat="server" Text="Patient Search"></asp:Label>
        </h1>

        <div class="row mb-3">
            <asp:Label ID="Label2" runat="server" Text="Label" class="col-sm-4 col-form-label">Initial</asp:Label>
            <asp:TextBox ID="txtInitial" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label3" runat="server" Text="Label" class="col-sm-4 col-form-label">Last Name</asp:Label>
            <asp:TextBox ID="txtLastName" runat="server" class="form-control"></asp:TextBox>
        </div>

        <div class="row mb-3">
            <asp:Label ID="Label7" runat="server" Text="Label" class="col-sm-4 col-form-label">NIC</asp:Label>
            <asp:TextBox ID="txtNIC" type="number" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label8" runat="server" Text="Label" class="col-sm-4 col-form-label">Passport</asp:Label>
            <asp:TextBox ID="txtPassport" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label11" runat="server" Text="Label" class="col-sm-4 col-form-label">Email Address</asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" type="email" class="form-control"></asp:TextBox>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label12" runat="server" Text="Label" class="col-sm-4 col-form-label">Mobile Number</asp:Label>
            <asp:TextBox ID="txtMobileNo" type="number" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label13" runat="server" Text="Label" class="col-sm-4 col-form-label">Telephone Number</asp:Label>
            <asp:TextBox ID="txtTelephoneNo" type="number" runat="server" class="form-control"></asp:TextBox>
        </div>

        <div class="d-grid gap-2 d-md-flex justify-content-md-end">
            <asp:Button ID="btnSearch" runat="server" class="btn btn-primary" Text="Search" OnClick="btnSearch_Click" />
            <asp:Button ID="btnReset" runat="server" class="btn btn-primary" Text="Reset" OnClick="btnReset_Click" />
            <asp:HiddenField ID="hdnPatientId" runat="server" />
        </div>
        <br />
        <asp:GridView ID="grdPatient" runat="server" class="table table-striped" AutoGenerateColumns="False" OnSelectedIndexChanging="grdPatient_SelectedIndexChanging" OnRowDeleting="grdPatient_RowDeleting">
            <Columns>
                <asp:BoundField DataField="patient_fullname" HeaderText="Name" />
                <asp:BoundField DataField="patient_nic" HeaderText="NIC" />
                <asp:BoundField DataField="patient_passport" HeaderText="Passport" />
                <asp:BoundField DataField="patient_email" HeaderText="Email" />
                <asp:BoundField DataField="patient_mobileno" HeaderText="Mobile No" />
                <asp:BoundField DataField="branch_name" HeaderText="Branch" />
                <asp:CommandField SelectText="Update" ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnGrdPatientId" runat="server" ClientIDMode="Predictable" Value='<%# Bind("patient_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
