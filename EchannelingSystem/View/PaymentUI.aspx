<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="PaymentUI.aspx.cs" Inherits="EchannelingSystem.View.PaymentUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <form method="post" action="<%= payhereurl %>">

        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="col-sm-4">
                        <div class="form-group">
                            <asp:Label ID="lblappsequence" runat="server" class="text-success" Text=""></asp:Label>
                            <input type="submit" value="Continue" class='btn btn-finish btn-fill btn-info btn-wd' style="padding: 10px 10px; width: 100%">
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <input type="hidden" name="merchant_id" value="<%= merchant_id %>">
        <input type="hidden" name="return_url" value="<%= return_url %>">
        <input type="hidden" name="cancel_url" value="<%= cancel_url %>">
        <input type="hidden" name="notify_url" value="<%= notify_url %>">
        <input type="hidden" name="items" value="">
        <input type="hidden" name="currency" value="<%= currency %>">
        <input type="hidden" name="amount" value="<%= amount %>">
        <input type="hidden" name="country" value="<%= country %>">

        <input type="hidden" name="first_name" value="<%= first_name %>">
        <input type="hidden" name="last_name" value="<%= last_name %>">
        <input type="hidden" name="email" value="<%= email %>">
        <input type="hidden" name="phone" value="<%= phone %>">
        <input type="hidden" name="address" value="<%= address %>">
        <input type="hidden" name="city" value="<%= city %>">
        <input type="hidden" name="hash" value="<%= hash %>">
        <input type="hidden" name="order_id" value="<%= order_id %>">
    </form>
</asp:Content>
