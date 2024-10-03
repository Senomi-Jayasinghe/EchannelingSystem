<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="MedicineCategoryUI.aspx.cs" Inherits="EchannelingSystem.View.MedicineCategoryUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bg-light p-5 my-5 border col-sm-8">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="HomeUI.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page"><b>Medicine Category</b></li>
            </ol>
        </nav>
        <div class="row mb-3">
            <asp:Label ID="Label2" runat="server" Text="Label" class="col-sm-4 col-form-label">Category</asp:Label>
            <asp:TextBox ID="txtMedCategory" runat="server" class="form-control" required></asp:TextBox>
        </div>
        <asp:Panel ID="pnlMsg" runat="server" Visible="false">
            <asp:Label ID="lblPnlMsg" runat="server" Text="Label"></asp:Label>
        </asp:Panel>
        <div class="d-grid gap-2 d-md-flex justify-content-md-end">
            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnReset" runat="server" class="btn btn-secondary" Text="Reset" OnClick="btnReset_Click" formnovalidate="formnovalidate"/>
            <asp:HiddenField ID="hdnMedicineCategoryId" runat="server" />
        </div>
        <br />
        <asp:GridView ID="grdMedicineCategory" runat="server" class="table table-striped" AutoGenerateColumns="false" OnRowDeleting="grdMedCategory_RowDeleting" OnSelectedIndexChanging="grdMedCategory_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="medicine_category_description" HeaderText="Category" />
                <asp:CommandField SelectText="Update" ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnGrdMedicineCategoryId" runat="server" ClientIDMode="Predictable" Value='<%# Bind("medicine_category_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
