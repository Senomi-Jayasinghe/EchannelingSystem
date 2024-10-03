<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="PaymentSuccessUI.aspx.cs" Inherits="EchannelingSystem.View.PaymentSuccessUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bg-light p-5 my-5 border col-lg-9">
        <div class="alert alert-success" role="alert">
            <asp:Label ID="lblSuccesss" Text="" runat="server"></asp:Label>
        </div>
        <div class="d-grid gap-2 d-md-flex justify-content-md-end">
            <asp:Button runat="server" ID="btnBack" Text="Back to Appointments" OnClick="btnBack_Click" class="btn btn-primary" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
