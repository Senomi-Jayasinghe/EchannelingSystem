<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="SymptomUI.aspx.cs" Inherits="EchannelingSystem.View.SymptomUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container bg-light p-5 my-5 border col-sm-8">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="HomeUI.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page"><b>Symptom</b></li>
            </ol>
        </nav>
        <div class="row mb-3">
            <asp:Label ID="Label2" runat="server" Text="Label" class="col-sm-4 col-form-label">Name</asp:Label>
            <asp:TextBox ID="txtSymptomName" runat="server" class="form-control" required></asp:TextBox>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label1" runat="server" Text="Description"></asp:Label>
            <textarea id="txtDescription" cols="20" rows="2" runat="server" class="form-control" required></textarea>
        </div>
        <asp:Panel ID="pnlMsg" runat="server" Visible="false">
            <asp:Label ID="lblPnlMsg" runat="server" Text="Label"></asp:Label>
        </asp:Panel>
        <div class="d-grid gap-2 d-md-flex justify-content-md-end">
            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" OnClick="btnSave_Click"/>
            <asp:Button ID="btnReset" runat="server" class="btn btn-secondary" Text="Reset" OnClick="btnReset_Click" formnovalidate="formnovalidate"/>
            <asp:HiddenField ID="hdnSymptomId" runat="server" />
        </div>
        <br />
        <asp:GridView ID="grdSymptom" runat="server" class="table table-striped" AutoGenerateColumns="false" OnRowDeleting="grdSymptom_RowDeleting" OnSelectedIndexChanging="grdSymptom_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="symptom_name" HeaderText="Name" />
                <asp:BoundField DataField="symptom_description" HeaderText="Description" />
                <asp:CommandField SelectText="Update" ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnGrdSymptomId" runat="server" ClientIDMode="Predictable" Value='<%# Bind("symptom_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
