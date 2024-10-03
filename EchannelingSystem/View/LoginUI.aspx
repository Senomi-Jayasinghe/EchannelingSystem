<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUI.aspx.cs" Inherits="EchannelingSystem.View.LoginUI" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Login Page</title>
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
            height: 440px;
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
        <!--Form Body-->
        <form id="form1" runat="server" class="w-50">
            <div class="container">
                <h3>
                    <asp:Label ID="lblHeader" runat="server" Text="Welcome to Echanneling"></asp:Label>
                </h3>
                <!--User Enters Email and Password-->
                <div class="form-group">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" type="email" class="form-control" ValidationGroup="LoginValidation" required TabIndex="1"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" class="form-control" ValidationGroup="LoginValidation" TextMode="Password" required TabIndex="2"></asp:TextBox>
                    <!--Error Message-->
                    <asp:Label ID="errMsg" class="text-danger" runat="server" Visible="false" Text="Login Error! Email or Password is Incorrect"></asp:Label>
                    <!--Forgot Password Button-->
                    <asp:Button ID="btnForgotPsw" runat="server" class="btn btn-link" Text="Forgot Password?" OnClick="btnForgotPsw_Click" formnovalidate="formnovalidate" TabIndex="4" />
                </div>
                <!--Login Button-->
                <asp:Button ID="btnLogin" class="btn btn-primary btn-block" runat="server" Text="Login" OnClick="btnLogin_Click" ValidationGroup="LoginGroup" TabIndex="3" />
                <hr class="text-bg-danger" />
                <p class="text-danger">Don't have an account yet? Sign Up Here.</p>
                <!--SignUp Button-->
                <asp:Button ID="btnSignUp" class="btn btn-primary btn-block" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" CausesValidation="false" formnovalidate="formnovalidate" TabIndex="5" />
            </div>
        </form>
    </div>
</body>
</html>
