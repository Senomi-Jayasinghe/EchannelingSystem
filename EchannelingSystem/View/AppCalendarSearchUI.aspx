<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="AppCalendarSearchUI.aspx.cs" Inherits="EchannelingSystem.View.PatientConsultantSearchUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bg-light p-5 my-5 border col-sm-10">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="HomeUI.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page"><b>Search for Appointments</b></li>
            </ol>
        </nav>
        <div class="row gy-2 gx-3 align-items-center">
            <div class="col-auto">
                <label class="small">Search by Name</label>
                <asp:TextBox runat="server" type="text" class="form-control" ID="txtName"></asp:TextBox>
            </div>
            <div class="col-auto">
                <label class="small">Search by Specialization</label>
                <asp:DropDownList runat="server" class="form-select" ID="ddlSpecialization"></asp:DropDownList>
            </div>
            <div class="col-auto">
                <label class="small">Date</label>
                <asp:TextBox ID="ddlDate" data-provide="datepicker" class="form-select" runat="server"></asp:TextBox>
            </div>
            <div class="col-auto">
                <label class="small">Search by Branch</label>
                <asp:DropDownList runat="server" class="form-select" ID="ddlBranch"></asp:DropDownList>
            </div>
            <div class="col-auto">
                <label class="small">Search by Gender</label>
                <asp:DropDownList ID="ddlGender" runat="server" class="form-select">
                    <asp:ListItem Text="" Value="" />
                    <asp:ListItem Text="Female" Value="F" />
                    <asp:ListItem Text="Male" Value="M" />
                </asp:DropDownList>
            </div>
            <div class="col-auto">
                <label class="small"></label>
                <asp:Button runat="server" Text="Search" ID="btnSearch" class="form-control btn btn-primary" OnClick="btnSearch_Click" />
            </div>
        </div>
    </div>
    <div class="container bg-light p-5 my-5 border col-sm-10">
        <asp:Label ID="PnlMsg" class="text-muted" runat="server"></asp:Label>
        <asp:Label ID="lblSearchResult" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
