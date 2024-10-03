<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="ConsultationUI.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="EchannelingSystem.View.ConsultationUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bg-light p-5 my-5 border col-sm-8">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item active" aria-current="page"><b>Consultation</b></li>
            </ol>
        </nav>
        <div class="row mb-3">
            <asp:Label ID="Label5" runat="server" Text="Label" class="col-sm-4 col-form-label">Next Visit</asp:Label>
            <asp:TextBox ID="ddlDateAvailable" class="form-control" data-provide="datepicker" runat="server"></asp:TextBox>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label8" runat="server" Text="Label" class="col-sm-4 col-form-label">Symptoms</asp:Label>

            <asp:DropDownList ID="ddlSymptoms" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSymptoms_SelectedIndexChanged">
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
        <div class="row mb-3">
            <asp:Label ID="Label1" runat="server" Text="Label" class="col-sm-4 col-form-label">Diseases</asp:Label>

            <asp:DropDownList ID="ddlDisease" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDisease_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:GridView ID="grdDisease" runat="server" class="table table-striped" OnRowCommand="grdDisease_RowCommand" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="diseaseName" HeaderText="Disease" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" CommandName="DeleteRow" Text="Delete" CommandArgument='<%# Container.DataItemIndex %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label2" runat="server" Text="Label" class="col-sm-4 col-form-label">Prescribed Medicine</asp:Label>

            <asp:DropDownList ID="ddlMedicine" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMedicine_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:GridView ID="grdMedicine" runat="server" class="table table-striped" OnRowCommand="grdMedicine_RowCommand" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="medicineDescription" HeaderText="Medicine" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" CommandName="DeleteRow" Text="Delete" CommandArgument='<%# Container.DataItemIndex %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="row mb-3">
            <asp:Label ID="Label3" runat="server" Text="Label" class="col-sm-4 col-form-label">Reports</asp:Label>

            <asp:DropDownList ID="ddlReport" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlReport_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:GridView ID="grdReport" runat="server" class="table table-striped" OnRowCommand="grdReport_RowCommand" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="reportDescription" HeaderText="Reports" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" CommandName="DeleteRow" Text="Delete" CommandArgument='<%# Container.DataItemIndex %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="d-grid gap-2 d-md-flex justify-content-md-end">
            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnReset" runat="server" class="btn btn-secondary" OnClick="btnReset_Click" Text="Reset" />
        </div>
    </div>
</asp:Content>
