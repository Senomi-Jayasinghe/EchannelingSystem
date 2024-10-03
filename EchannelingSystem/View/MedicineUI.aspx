<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="MedicineUI.aspx.cs" Inherits="EchannelingSystem.View.MedicineUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bg-light p-5 my-5 border col-sm-8">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="HomeUI.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page"><b>Medicine</b></li>
            </ol>
        </nav>
        <div class="row mb-3">
            <asp:Label ID="lblCategory" runat="server" Text="Category" class="col-sm-4 col-form-label"></asp:Label>
            <asp:DropDownList ID="ddlMedCategory" runat="server" class="form-control"></asp:DropDownList>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label2" runat="server" Text="Label" class="col-sm-4 col-form-label">Description</asp:Label>
            <asp:TextBox ID="txtMedicineDesc" runat="server" class="form-control" required></asp:TextBox>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label1" runat="server" Text="Label" class="col-sm-4 col-form-label">Scientific Name</asp:Label>
            <asp:TextBox ID="txtScientificName" runat="server" class="form-control" required></asp:TextBox>
        </div>
        <div class="d-grid gap-2 d-md-flex justify-content-md-end">
            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnReset" runat="server" class="btn btn-secondary" Text="Reset" OnClick="btnReset_Click" formnovalidate="formnovalidate"/>
            <asp:HiddenField ID="hdnMedicineId" runat="server" />
        </div>
        <br />
        <asp:Panel ID="pnlMsg" runat="server" Visible="false">
            <asp:Label ID="lblPnlMsg" runat="server" Text="Label"></asp:Label>
        </asp:Panel>
        <asp:GridView ID="grdMedicine" runat="server" class="table table-striped" AutoGenerateColumns="false" OnRowDeleting="grdMedicine_RowDeleting" OnSelectedIndexChanging="grdMedicine_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="medicine_category_description" HeaderText="Medicine Category" />
                <asp:BoundField DataField="medicine_description" HeaderText="Description" />
                <asp:BoundField DataField="medicine_scientificname" HeaderText="Scientific Name" />
                <asp:CommandField SelectText="Update" ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnGrdMedicineId" runat="server" ClientIDMode="Predictable" Value='<%# Bind("medicine_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
