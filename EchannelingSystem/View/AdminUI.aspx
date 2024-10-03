<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="AdminUI.aspx.cs" Inherits="EchannelingSystem.View.AdminUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bg-light p-5 my-5 border col-sm-8">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="HomeUI.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page"><b>Admin</b></li>
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
        <br />

        <asp:Panel ID="pnlMsg" runat="server" Visible="false">
            <asp:Label ID="lblPnlMsg" runat="server" Text="Label"></asp:Label>
        </asp:Panel>

        <div class="d-grid gap-2 d-md-flex justify-content-md-end">
            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" OnClick="btnSave_Click" Text="Save" />
            <asp:Button ID="btnReset" runat="server" class="btn btn-secondary" Text="Reset" OnClick="btnReset_Click" formnovalidate="formnovalidate" />
            <asp:HiddenField ID="hdnAdminId" runat="server" />
        </div>
        <br />
        <asp:GridView ID="grdAdmin" runat="server" class="table table-striped" AutoGenerateColumns="false" OnRowDeleting="grdAdmin_RowDeleting" OnSelectedIndexChanging="grdAdmin_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="admin_title_id" HeaderText="Title" />
                <asp:BoundField DataField="admin_fullname" HeaderText="Name" />
                <asp:BoundField DataField="admin_nic" HeaderText="NIC" />
                <asp:BoundField DataField="admin_email" HeaderText="Email" />
                <asp:BoundField DataField="admin_mobileno" HeaderText="Mobile" />
                <asp:BoundField DataField="admin_telephoneno" HeaderText="Telephone" />
                <asp:CommandField SelectText="Update" ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnGrdAdminId" runat="server" ClientIDMode="Predictable" Value='<%# Bind("admin_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
