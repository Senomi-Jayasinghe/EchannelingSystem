<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="PaymentCategoryUI.aspx.cs" Inherits="EchannelingSystem.View.PaymentCategoryUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bg-light p-5 my-5 border col-sm-8">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="HomeUI.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page"><b>Payment Category</b></li>
            </ol>
        </nav>
        <div class="row mb-3">
            <asp:Label ID="Label2" runat="server" Text="Label" class="col-sm-4 col-form-label">Name</asp:Label>
            <asp:TextBox ID="txtPaymentCategory" runat="server" class="form-control" required></asp:TextBox>
        </div>
        <asp:Panel ID="pnlMsg" runat="server" Visible="false">
            <asp:Label ID="lblPnlMsg" runat="server" Text="Label"></asp:Label>
        </asp:Panel>
        <div class="d-grid gap-2 d-md-flex justify-content-md-end">
            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" OnClick="btnSave_Click"/>
            <asp:Button ID="btnReset" runat="server" class="btn btn-secondary" Text="Reset" OnClick="btnReset_Click" formnovalidate="formnovalidate"/>
            <asp:HiddenField ID="hdnPaymentCategoryId" runat="server" />
        </div>
        <br />
        <asp:GridView ID="grdPaymentCategory" runat="server" class="table table-striped" AutoGenerateColumns="false" OnRowDeleting="grdPaymentCategory_RowDeleting" OnSelectedIndexChanging="grdPaymentCategory_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="category_description" HeaderText="Category" />
                <asp:CommandField SelectText="Update" ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnGrdPaymentCategoryId" runat="server" ClientIDMode="Predictable" Value='<%# Bind("payment_category_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
