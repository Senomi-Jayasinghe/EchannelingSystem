<%@ Page Title="" Language="C#" MasterPageFile="~/Echanneling.Master" AutoEventWireup="true" CodeBehind="CalendarUI.aspx.cs" Inherits="EchannelingSystem.View.CalendarUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bg-light p-5 my-5 border col-sm-8">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="ConsultantHomeUI.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page"><b>Calendar</b></li>
            </ol>
        </nav>
        <div class="row mb-3">
            <div class="col-sm">
                <asp:Label ID="Label5" runat="server" Text="Label" class="col-sm-4 col-form-label">Enter Available Date</asp:Label>
                <asp:TextBox ID="ddlDateAvailable" class="form-control" data-provide="datepicker" runat="server" required></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label1" runat="server" Text="Label" class="col-sm-4 col-form-label">From</asp:Label>
                <asp:TextBox ID="txtFrom" class="form-control" runat="server" type="time" required></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label2" runat="server" Text="Label" class="col-sm-4 col-form-label">To</asp:Label>
                <asp:TextBox ID="txtTo" class="form-control" runat="server" type="time" required></asp:TextBox>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-sm">
                <asp:Label ID="Label3" runat="server" Text="Label" class="col-sm-4 col-form-label">Web Quota</asp:Label>
                <asp:TextBox ID="txtWebQuota" runat="server" class="form-control" required></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label4" runat="server" Text="Label" class="col-sm-4 col-form-label">Offline Quota</asp:Label>
                <asp:TextBox ID="txtOfflineQuota" runat="server" class="form-control" required></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label6" runat="server" Text="Label" class="col-sm-4 col-form-label">Booked Appointments</asp:Label>
                <asp:TextBox ID="txtBalance" runat="server" class="form-control" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-3 ">
            <div class="col-sm">
                <asp:Label ID="Label15" runat="server" Text="Label" class="col-sm-4 col-form-label">Branch</asp:Label>
                <asp:DropDownList ID="ddlBranch" runat="server" class="form-control" required></asp:DropDownList>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label12" runat="server" Text="Label" class="col-sm-4 col-form-label">Consultation Fee</asp:Label>
                <div class="input-group mb-2">
                    <div class="input-group-prepend">
                        <div class="input-group-text">Rs.</div>
                    </div>
                    <asp:TextBox ID="txtConsultationFee" runat="server" class="form-control" required></asp:TextBox>
                </div>
            </div>
        </div>
        <asp:Panel ID="pnlMsg" runat="server" Visible="false">
            <asp:Label ID="lblPnlMsg" runat="server" Text="Label"></asp:Label>
        </asp:Panel>
        <div class="d-grid gap-2 d-md-flex justify-content-md-end">
            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnReset" runat="server" class="btn btn-secondary" OnClick="btnReset_Click" Text="Reset" formnovalidate="formnovalidate" />
            <asp:HiddenField ID="hdnCalendarId" runat="server" />
        </div>
        <br />
      <%--  if the calendar is in view mode, the grid will be visible--%>
        <asp:GridView ID="grdPatients" runat="server" class="table table-striped" AutoGenerateColumns="False" OnRowCommand="grdCalendar_RowCommand">
            <Columns>
                <asp:BoundField DataField="patient_fullname" HeaderText="Name" />
                <asp:BoundField DataField="patient_gender" HeaderText="Gender" />
                <asp:BoundField DataField="patient_mobileno" HeaderText="Contact" />
                <asp:BoundField DataField="patient_age" HeaderText="Age" />
                <asp:BoundField DataField="appointment_seq" HeaderText="Sequence" />
                <asp:ButtonField Text="Consult" CommandName="View" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnPatientId" runat="server" ClientIDMode="Predictable" Value='<%# Bind("patient_id") %>' />
                        <asp:HiddenField ID="hdnAppointmentId" runat="server" ClientIDMode="Predictable" Value='<%# Bind("appointment_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
