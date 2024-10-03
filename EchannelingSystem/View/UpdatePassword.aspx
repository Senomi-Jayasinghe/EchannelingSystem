<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="EchannelingSystem.View.UpdatePassword1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bg-light p-5 my-5 border col-sm-6">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="HomeUI.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page"><b>Update Password</b></li>
            </ol>
        </nav>
        <div class="container">
            <h3>
                <asp:Label ID="lblHeader" runat="server" Text="Update Password"></asp:Label>
            </h3>
            <div class="form-group">
                <asp:Label ID="lblOldPassword" runat="server" Text="Enter Old Password"></asp:Label>
                <asp:TextBox ID="txtOldPassword" runat="server" class="form-control" required></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblNewPassword" runat="server" Text="Enter New Password"></asp:Label>
                <asp:TextBox ID="txtNewPassword" runat="server" class="form-control" required></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblConfirm" runat="server" Text="Confirm Password"></asp:Label>
                <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" class="form-control" required></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="btnChange" class="btn btn-primary btn-block" runat="server" Text="Change" OnClick="btnChange_Click" />
            <br />
            <asp:Panel ID="pnlMsg" runat="server" Visible="false">
                <asp:Label ID="lblPnlMsg" runat="server" Text="Label"></asp:Label>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
