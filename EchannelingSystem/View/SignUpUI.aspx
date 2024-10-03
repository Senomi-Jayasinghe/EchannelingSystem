<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUpUI.aspx.cs" Inherits="EchannelingSystem.View.SignUpUI" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>SignUp Page</title>
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
            height: 525px;
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
                    <asp:Label ID="lblHeader" runat="server" Text="Sign Up"></asp:Label>
                </h3>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Label">Initial</asp:Label>
                    <asp:TextBox ID="txtInitial" runat="server" class="form-control" required></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Label">Last Name</asp:Label>
                    <asp:TextBox ID="txtLastName" runat="server" class="form-control" required></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblEmail" runat="server" Text="Enter Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" type="email" class="form-control" required></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Create Password"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" class="form-control" TextMode="Password" required></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Confirm Password"></asp:Label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" class="form-control" TextMode="Password" required></asp:TextBox>
                </div>
                <asp:Label ID="lblMessage" runat="server" class="text-danger" />
                <asp:Button ID="btnCreate" runat="server" Text="Create Account" class="btn btn-primary btn-block" OnClick="btnCreate_Click" />
            </div>
        </form>
    </div>
</body>
</html>
