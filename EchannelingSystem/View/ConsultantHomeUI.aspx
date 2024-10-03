<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="ConsultantHomeUI.aspx.cs" Inherits="EchannelingSystem.View.ConsultantHomeUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container m-auto mt-5">
        <div class="row row-cols-1 row-cols-md-4 g-4">
            <div class="col">
                <a href="ConsultantCalendars.aspx" style="text-decoration: none;">
                    <div class="card" style="width: 240px; height: 421px;">
                        <img src='<%= ResolveUrl("~/Images/Calendar.jpg") %>' class="card-img-top" style="width: 235px; height: 235px;">
                        <div class="card-body">
                            <h5 class="card-title">My Calendar</h5>
                            <p class="card-text">Manage and view your scheduled appointments and events.</p>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col">
                <a href="CalendarUI.aspx" style="text-decoration: none;">
                    <div class="card" style="width: 240px; height: 421px;">
                        <img src='<%= ResolveUrl("~/Images/Availability.jpg") %>' class="card-img-top" style="width: 235px; height: 235px;">
                        <div class="card-body">
                            <h5 class="card-title">Add Availability</h5>
                            <p class="card-text">Add your availability to keep your schedule up-to-date.</p>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col">
                <a href="DiseaseKnowledgeUI.aspx" style="text-decoration: none;">
                    <div class="card" style="width: 240px; height: 421px;">
                        <img src='<%= ResolveUrl("~/Images/diseasedb.png") %>' class="card-img-top" style="width: 235px; height: 235px;">
                        <div class="card-body">
                            <h5 class="card-title">Disease Knowledge Database</h5>
                            <p class="card-text">Explore a database that links symptoms to potential health conditions for better understanding.</p>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col">
                <a href="ConsultantReportsUI.aspx" style="text-decoration: none;">
                    <div class="card" style="width: 240px; height: 421px;">
                        <img src='<%= ResolveUrl("~/Images/report.jpg") %>' class="card-img-top" style="width: 235px; height: 235px;">
                        <div class="card-body">
                            <h5 class="card-title">Reports</h5>
                            <p class="card-text">View detailed summaries of your appointment history and health data.</p>
                        </div>
                    </div>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
