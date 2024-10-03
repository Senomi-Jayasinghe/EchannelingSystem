<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="BranchUI.aspx.cs" Inherits="EchannelingSystem.View.BranchUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container bg-light p-5 my-5 border col-sm-8">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="HomeUI.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page"><b>Branch</b></li>
            </ol>
        </nav>
        <div class="row mb-3">
            <asp:Label ID="Label2" runat="server" Text="Label" class="col-sm-4 col-form-label">Name</asp:Label>
            <asp:TextBox ID="txtBranchName" runat="server" class="form-control" required></asp:TextBox>
        </div>

        <div class="row mb-3">
            <asp:Label ID="Label9" runat="server" Text="Label" class="col-sm-4 col-form-label">Address</asp:Label>
            <textarea id="txtBranchAddress" cols="20" rows="2" runat="server" class="form-control" required></textarea>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label11" runat="server" Text="Label" class="col-sm-4 col-form-label">Email Address</asp:Label>
            <asp:TextBox ID="txtBranchEmail" runat="server" type="email" class="form-control" required></asp:TextBox>
        </div>

        <div class="row mb-3">
            <asp:Label ID="Label13" runat="server" Text="Label" class="col-sm-4 col-form-label">Contact Number</asp:Label>
            <asp:TextBox ID="txtBranchContact" runat="server" pattern="^0\d{9}$" title="Please enter a phone number starting with '0' followed by nine digits." class="form-control" required></asp:TextBox>
        </div>

        <div class="row mb-3">
            <asp:Label ID="Label14" runat="server" Text="Label" class="col-sm-4 col-form-label">Contact Person</asp:Label>
            <asp:TextBox ID="txtContactPerson" runat="server" class="form-control" required></asp:TextBox>
        </div>

        <asp:Panel ID="pnlMsg" runat="server" Visible="false">
            <asp:Label ID="lblPnlMsg" runat="server" Text="Label"></asp:Label>
        </asp:Panel>

        <div class="d-grid gap-2 d-md-flex justify-content-md-end">
            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" OnClick="btnSave_Click" ValidationGroup="g1" />
            <asp:Button ID="btnReset" runat="server" class="btn btn-secondary" Text="Reset" OnClick="btnReset_Click" formnovalidate="formnovalidate" />
            <asp:HiddenField ID="hdnBranchId" runat="server" />
        </div>
        <br />
        <div class="table-responsive">
            <asp:GridView ID="grdBranch" runat="server" class="table table-striped" AutoGenerateColumns="False" OnRowDeleting="grdBranch_RowDeleting" OnSelectedIndexChanging="grdBranch_SelectedIndexChanging">
                <Columns>
                    <asp:BoundField DataField="branch_name" HeaderText="Name" />
                    <asp:BoundField DataField="branch_address" HeaderText="Address" />
                    <asp:BoundField DataField="branch_email" HeaderText="E-mail" />
                    <asp:BoundField DataField="branch_contact" HeaderText="Contact No" />
                    <asp:BoundField DataField="branch_contact_person" HeaderText="Contact Person" />
                    <asp:CommandField SelectText="Update" ShowSelectButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnGrdBranchId" runat="server" ClientIDMode="Predictable" Value='<%# Bind("branch_id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
