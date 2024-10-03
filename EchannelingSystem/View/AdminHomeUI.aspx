<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="AdminHomeUI.aspx.cs" Inherits="EchannelingSystem.View.AdminHomeUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container m-auto mt-5">
        <div class="row row-cols-1 row-cols-md-4 g-4">
            <div class="col">
                <a href="ConsultantUI.aspx" style="text-decoration: none;">
                    <div class="card" style="width: 240px; height: 421px;">
                        <img src='<%= ResolveUrl("~/Images/diseasedb.png") %>' class="card-img-top" style="width: 235px; height: 235px;">
                        <div class="card-body">
                            <h5 class="card-title">Consultant</h5>
                            <p class="card-text">Register a New Consultant</p>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col">
                <a href="PatientUI.aspx" style="text-decoration: none;">
                    <div class="card" style="width: 240px; height: 421px;">
                        <img src='<%= ResolveUrl("~/Images/patient.jpg") %>' class="card-img-top" style="width: 235px; height: 235px;">
                        <div class="card-body">
                            <h5 class="card-title">Patient</h5>
                            <p class="card-text">Register a New Patient</p>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col">
                <a href="AdminUI.aspx" style="text-decoration: none;">
                    <div class="card" style="width: 240px; height: 421px;">
                        <img src='<%= ResolveUrl("~/Images/admin.jpg") %>' class="card-img-top" style="width: 235px; height: 235px;">
                        <div class="card-body">
                            <h5 class="card-title">Admin</h5>
                            <p class="card-text">Manage and View Admin Details</p>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col">
                <a href="ConsultantSearchUI.aspx" style="text-decoration: none;">
                    <div class="card" style="width: 240px; height: 421px;">
                        <img src='<%= ResolveUrl("~/Images/consultantsearch.jpg") %>' class="card-img-top" style="width: 235px; height: 235px;">
                        <div class="card-body">
                            <h5 class="card-title">Search for Consultants</h5>
                            <p class="card-text">Search, View, and Manage Consultant Details</p>
                        </div>
                    </div>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
