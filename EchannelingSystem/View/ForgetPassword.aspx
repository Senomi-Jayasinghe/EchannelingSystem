<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="EchannelingSystem.View.UpdatePassword" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Update Password</title>
    <link href="<%= ResolveUrl("~/Content/bootstrap.min.css") %>" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <style>
        body, html {
            height: 100%;
            margin: 0;
        }

        .bg {
            background-image: url('<%= ResolveUrl("~/Images/healthcare.jpg") %>');
            background-size: cover;
            background-position: center;
            height: 100%;
            display: flex;
            align-items: center;
        }

        .container {
            background: rgba(255, 255, 255,0.9);
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
            width: 100%;
            max-width: 450px;
            height: 270px;
        }

        h3 {
            text-align: center;
        }
    </style>
    <script src="<%= ResolveUrl("~/Scripts/jquery-3.5.1.slim.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/Scripts/bootstrap.bundle.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/Scripts/bootstrap-datepicker.js") %>"></script>
</head>
<body>
    <div class="bg">
        <form id="form1" runat="server" class="w-50">
            <div class="container">
                <h3>
                    <asp:Label ID="lblHeader" runat="server" Text="Forgot Password"></asp:Label>
                </h3>
                <p>Enter your Email Address, we will send you a new password.</p>
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Enter Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" required></asp:TextBox>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:Button ID="btnSend" class="btn btn-primary btn-block" runat="server" Text="Send" OnClick="btnSend_Click" />
                    </div>
                    <div class="col">
                        <asp:Button ID="btnCancel" class="btn btn-primary btn-block" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            CausesValidation="false" formnovalidate="formnovalidate" />
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
