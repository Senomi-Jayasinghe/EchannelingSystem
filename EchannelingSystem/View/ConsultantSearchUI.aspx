<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="ConsultantSearchUI.aspx.cs" Inherits="EchannelingSystem.View.ConsultantSearchUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bg-light p-5 my-5 border col-sm-8">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="HomeUI.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page"><b>Consultant Search</b></li>
            </ol>
        </nav>
        <div class="row mb-3">
            <asp:Label ID="Label2" runat="server" Text="Label" class="col-sm-4 col-form-label">Initial</asp:Label>
            <asp:TextBox ID="txtInitial" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label3" runat="server" Text="Label" class="col-sm-4 col-form-label">Last Name</asp:Label>
            <asp:TextBox ID="txtLastName" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label16" runat="server" Text="Label" class="col-sm-4 col-form-label">Register ID</asp:Label>
            <asp:TextBox type="number" ID="txtRegisterID" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label12" runat="server" Text="Label" class="col-sm-4 col-form-label">Contact Number</asp:Label>
            <asp:TextBox ID="txtContactNo" type="number" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label11" runat="server" Text="Label" class="col-sm-4 col-form-label">Email Address</asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" type="email" class="form-control"></asp:TextBox>
        </div>
        <div class="d-grid gap-2 d-md-flex justify-content-md-end">
            <asp:Button ID="btnSearch" runat="server" class="btn btn-primary" Text="Search" OnClick="btnSearch_Click" />
            <asp:Button ID="btnReset" runat="server" class="btn btn-primary" Text="Reset" OnClick="btnReset_Click" />
            <asp:HiddenField ID="hdnConsultantId" runat="server" />
        </div>
        <br />
        <asp:GridView ID="grdConsultant" runat="server" class="table table-striped" AutoGenerateColumns="False" OnSelectedIndexChanging="grdConsultant_SelectedIndexChanging" OnRowDeleting="grdConsultant_RowDeleting">
            <Columns>
                <asp:BoundField DataField="consultant_fullname" HeaderText="Name" />
                <asp:BoundField DataField="consultant_register_id" HeaderText="Register ID" />
                <asp:BoundField DataField="consultant_contact_1" HeaderText="Contact No" />
                <asp:BoundField DataField="consultant_email" HeaderText="Email" />
                <asp:BoundField DataField="consultant_hospital" HeaderText="Hospital" />
                <asp:CommandField SelectText="Update" ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnGrdConsultantId" runat="server" ClientIDMode="Predictable" Value='<%# Bind("consultant_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
