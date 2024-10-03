<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="DieaseUI.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="EchannelingSystem.View.DieaseUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bg-light p-5 my-5 border col-sm-8">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="HomeUI.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page"><b>Disease</b></li>
            </ol>
        </nav>
        <div class="row mb-3">
            <asp:Label ID="Label2" runat="server" Text="Label" class="col-sm-4 col-form-label">Name</asp:Label>
            <asp:TextBox ID="txtDiseaseName" runat="server" class="form-control" required></asp:TextBox>
        </div>

        <div class="row mb-3">
            <asp:Label ID="Label1" runat="server" Text="Description"></asp:Label>
            <textarea id="txtDescription" cols="20" rows="2" runat="server" class="form-control" required></textarea>
        </div>

        <div class="row mb-3">
            <asp:Label ID="Label8" runat="server" Text="Label" class="col-sm-4 col-form-label">Symptoms</asp:Label>

            <asp:DropDownList ID="ddlSymptoms" runat="server" class="form-control mb-2" AutoPostBack="true" OnSelectedIndexChanged="ddlSymptoms_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:GridView ID="grdSymptoms" runat="server" class="table table-striped" OnRowCommand="grdSymptoms_RowCommand" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="symptomName" HeaderText="Symptom" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" CommandName="DeleteRow" Text="Delete" CommandArgument='<%# Container.DataItemIndex %>' />
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
            <asp:Button ID="btnReset" runat="server" class="btn btn-secondary" OnClick="btnReset_Click" Text="Reset" formnovalidate="formnovalidate" />
            <asp:HiddenField ID="hdnDiseaseId" runat="server" />
        </div>

        <asp:GridView ID="grdDisease" runat="server" class="table table-striped" AutoGenerateColumns="false" OnRowDeleting="grdDisease_RowDeleting" OnSelectedIndexChanging="grdDisease_SelectedIndexChanging">
            <Columns>
                <asp:BoundField DataField="disease_name" HeaderText="Name" />
                <asp:BoundField DataField="disease_description" HeaderText="Description" />
                <asp:CommandField SelectText="Update" ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnGrdDiseaseId" runat="server" ClientIDMode="Predictable" Value='<%# Bind("disease_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
