<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="ConsultantCalendars.aspx.cs" Inherits="EchannelingSystem.View.ConsultantCalendars" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bg-light p-5 my-5 border col-sm-8">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="ConsultantHomeUI.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page"><b>Calendar</b></li>
            </ol>
            <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                <a href="CalendarUI.aspx" class="btn btn-primary btn-sm">Add</a>
            </div>
        </nav>
        <br />
        <asp:Label ID="PnlMsg" class="text-muted" runat="server" Visible="false" Text="No Availability Added Yet"></asp:Label>
        <asp:HiddenField ID="hdnCalendarId" runat="server" />
        <%--Consultant's Calendar--%>
        <asp:GridView ID="grdCalendar" runat="server" class="table table-striped" AutoGenerateColumns="False" 
            OnRowCommand="grdCalendar_RowCommand" >
            <Columns>
                <asp:BoundField DataField="date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" HtmlEncode="False"/>
                <asp:BoundField DataField="from_time" HeaderText="From" />
                <asp:BoundField DataField="to_time" HeaderText="To" />
                <asp:BoundField DataField="balance" HeaderText="Patients" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:ButtonField Text="View" CommandName="View" />
                <asp:ButtonField Text="Update" CommandName="Update" />
                <asp:ButtonField Text="Delete" CommandName="Delete" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnGrdCalendarId" runat="server" ClientIDMode="Predictable" Value='<%# Bind("appCalendar_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
