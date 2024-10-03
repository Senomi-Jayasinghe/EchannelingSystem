<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="ConsultantUI.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="EchannelingSystem.View.ConsultantUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container bg-light p-5 my-5 border col-lg-9">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="HomeUI.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page"><b>Consultant</b></li>
            </ol>
        </nav>
        <div class="row">
            <div class="col-sm">
                <asp:Label ID="lblTitle" runat="server" Text="Label" class="col-sm-4 col-form-label">Title</asp:Label>
                <asp:DropDownList ID="ddlTitle" runat="server" class="form-control" AutoPostBack="True" required>
                    <asp:ListItem Text="Select" Value="0" />
                    <asp:ListItem Text="Mr" Value="1" />
                    <asp:ListItem Text="Mrs" Value="2" />
                    <asp:ListItem Text="Miss" Value="2" />
                    <asp:ListItem Text="Master" Value="2" />
                </asp:DropDownList>
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
                <asp:TextBox ID="ddlDateOfBirth" data-provide="datepicker" class="form-control" runat="server" required></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label6" runat="server" Text="Label" class="col-sm-4 col-form-label">Gender</asp:Label>

                <asp:DropDownList ID="ddlGender" runat="server" class="form-control" required>
                    <asp:ListItem Text="Select" Value="0" />
                    <asp:ListItem Text="Female" Value="F" />
                    <asp:ListItem Text="Male" Value="M" />
                </asp:DropDownList>

            </div>
        </div>
        <div class="row">
            <div class="col-sm">
                <asp:Label ID="Label16" runat="server" Text="Label" class="col-sm-4 col-form-label">Register ID</asp:Label>
                <asp:TextBox type="number" ID="txtRegisterID" runat="server" class="form-control" required></asp:TextBox>

            </div>
            <div class="col-sm">
                <asp:Label ID="Label9" runat="server" Text="Label" class="col-sm-4 col-form-label">Address</asp:Label>
                <textarea id="txtAddress" cols="20" rows="2" runat="server" class="form-control" required></textarea>

            </div>
        </div>
        <div class="row">
            <div class="col-sm">
                <asp:Label ID="Label12" runat="server" Text="Label" class="col-sm-4 col-form-label">Contact Number 1</asp:Label>
                <asp:TextBox ID="txtContactNumber1" runat="server" class="form-control" pattern="^0\d{9}$" title="Please enter a phone number starting with '0' followed by nine digits." required></asp:TextBox>

            </div>
            <div class="col-sm">
                <asp:Label ID="Label13" runat="server" Text="Label" class="col-sm-4 col-form-label">Contact Number 2</asp:Label>
                <asp:TextBox ID="txtContactNumber2" runat="server" class="form-control" pattern="^0\d{9}$" title="Please enter a phone number starting with '0' followed by nine digits." required></asp:TextBox>

            </div>
        </div>
        <div class="row">
            <div class="col-sm">
                <asp:Label ID="Label11" runat="server" Text="Label" class="col-sm-4 col-form-label">Email Address</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" type="email" class="form-control" required></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label14" runat="server" Text="Label" class="col-sm-4 col-form-label">Hospital</asp:Label>
                <asp:TextBox ID="txtHospital" runat="server" class="form-control" required></asp:TextBox>

            </div>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label7" runat="server" Text="Label" class="col-sm-4 col-form-label">Qualifications</asp:Label>

            <asp:DropDownList ID="ddlQualification" runat="server" class="form-control mb-2" AutoPostBack="true" OnSelectedIndexChanged="ddlQualification_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:GridView ID="grdQualification" runat="server" class="table table-striped" OnRowCommand="grdQualification_RowCommand" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="qualificationDescription" HeaderText="Qualification" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" CommandName="DeleteRow" Text="Delete" CommandArgument='<%# Container.DataItemIndex %>' formnovalidate="formnovalidate"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
        <div class="row mb-3">
            <asp:Label ID="Label8" runat="server" Text="Label" class="col-sm-4 col-form-label">Specialization</asp:Label>

            <asp:DropDownList ID="ddlSpecialization" runat="server" class="form-control mb-2" AutoPostBack="true" OnSelectedIndexChanged="ddlSpecialization_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:GridView ID="grdSpecialization" runat="server" class="table table-striped" OnRowCommand="grdSpecialization_RowCommand" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="specializationDescription" HeaderText="Specialization" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" CommandName="DeleteRow" Text="Delete" CommandArgument='<%# Container.DataItemIndex %>' formnovalidate="formnovalidate"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>

        <asp:Panel ID="pnlMsg" runat="server" Visible="false">
            <asp:Label ID="lblPnlMsg" runat="server" Text="Label"></asp:Label>
        </asp:Panel>

        <div class="d-grid gap-2 d-md-flex justify-content-md-end">
            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnReset" runat="server" class="btn btn-secondary" Text="Reset" OnClick="btnReset_Click" formnovalidate="formnovalidate"/>
            <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-secondary" OnClientClick="window.history.go(-1); return false;" Visible="false" />
            <asp:HiddenField ID="hdnConsultantId" runat="server" />
        </div>
    </div>
</asp:Content>

