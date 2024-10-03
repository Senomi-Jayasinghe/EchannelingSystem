using EchannelingSystem.Controller;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchannelingSystem.View
{
    public partial class CalendarUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ROLE"].ToString() != "2")
            {
                Response.Redirect("LoginUI.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    getBranchData();
                    int appCalendarID;
                    if (int.TryParse(Request.QueryString["appCalendarID"], out appCalendarID))
                    {
                        getData(appCalendarID);

                        if (Request.QueryString["mode"] == "U")
                        {
                            updateCalendar();
                        }
                        else if (Request.QueryString["mode"] == "D")
                        {
                            deleteCalendar();
                        }
                        else if (Request.QueryString["mode"] == "V")
                        {
                            viewPatients(appCalendarID);
                            btnSave.Visible = false;
                            btnReset.Visible = false;
                        }
                    }
                }
            }
        }
        protected void getBranchData()
        {
            BranchController branchController = new BranchController();
            DataTable dt = new DataTable();
            dt = branchController.GetBranch();

            ddlBranch.DataSource = dt;
            ddlBranch.DataTextField = "branch_name";
            ddlBranch.DataValueField = "branch_id";
            ddlBranch.DataBind();

            ddlBranch.Items.Insert(0, new ListItem("Select Branch", "0"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AppCalendar appCalendar = new AppCalendar();
                AppCalendarController appCalendarController = new AppCalendarController();
                appCalendar.consultantID = Convert.ToInt32(Session["USER_ID"]);
                appCalendar.date = Convert.ToDateTime(ddlDateAvailable.Text);
                appCalendar.fromTime = txtFrom.Text;
                appCalendar.toTime = txtTo.Text;
                appCalendar.entryUser = Convert.ToInt32(Session["USER_ID"]);
                appCalendar.entryDate = DateTime.Now;

                if (appCalendar.date < DateTime.Now)
                {
                    throw new ArgumentException("Select a valid date");
                }

                if (Convert.ToDateTime(appCalendar.toTime) <= Convert.ToDateTime(appCalendar.fromTime))
                {
                    throw new ArgumentException("ToTime must be greater than FromTime");
                }
                appCalendar.webQuota = Convert.ToInt32(txtWebQuota.Text);
                appCalendar.offlineQuota = Convert.ToInt32(txtOfflineQuota.Text);
                if (!string.IsNullOrEmpty(txtBalance.Text))
                {
                    appCalendar.balance = Convert.ToInt32(txtBalance.Text);
                }
                appCalendar.branchID = Convert.ToInt32(ddlBranch.SelectedValue);
                appCalendar.consultationFee = Convert.ToDecimal(txtConsultationFee.Text);

                if (btnSave.Text == "Save")
                {
                    appCalendar.balance = 0;
                    txtBalance.Text = appCalendar.balance.ToString();
                    appCalendar.status = "A";
                    appCalendarController.SaveAppointment(appCalendar);
                    lblPnlMsg.Text = "Save Success";
                }
                else if (btnSave.Text == "Update")
                {
                    appCalendar.status = "A";
                    appCalendar.appCalendarID = Convert.ToInt32(hdnCalendarId.Value);
                    appCalendarController.UpdateAppointment(appCalendar);
                    lblPnlMsg.Text = "Update Success";
                }
                else if (btnSave.Text == "Delete")
                {
                    if (Convert.ToInt32(txtBalance.Text) > 0)
                    {
                        lblPnlMsg.Text = "An Appointment has already been made, cannot delete Availability";
                    }
                    else
                    {
                        appCalendar.status = "I";
                        appCalendar.appCalendarID = Convert.ToInt32(hdnCalendarId.Value);
                        appCalendarController.DeleteAppointment(appCalendar);
                        lblPnlMsg.Text = "Delete Success";
                    }
                }
                pnlMsg.Visible = true;
                pnlMsg.CssClass = "alert alert-success";
            }
            catch (Exception ex)
            {
                pnlMsg.Visible = true;
                lblPnlMsg.Text = "Save Error!" + ex.Message;
                pnlMsg.CssClass = "alert alert-danger";
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlDateAvailable.Text = string.Empty;
            txtFrom.Text = string.Empty;
            txtTo.Text = string.Empty;
            txtWebQuota.Text = string.Empty;
            txtOfflineQuota.Text = string.Empty;
            txtBalance.Text = string.Empty;
            ddlBranch.SelectedIndex = 0;
            txtConsultationFee.Text = string.Empty;
        }

        protected void getData(int appCalendarId)
        {
            AppCalendarController appCalendarController = new AppCalendarController();
            AppCalendar appCalendar = appCalendarController.getAppCalendarByID(appCalendarId);

            ddlDateAvailable.Text = appCalendar.date.ToString("MM/dd/yyyy");
            txtFrom.Text = appCalendar.fromTime.ToString();
            txtTo.Text = appCalendar.toTime.ToString();
            txtWebQuota.Text = appCalendar.webQuota.ToString();
            txtOfflineQuota.Text = appCalendar.offlineQuota.ToString();
            txtBalance.Text = appCalendar.balance.ToString();
            ddlBranch.SelectedValue = appCalendar.branchID.ToString();
            txtConsultationFee.Text = appCalendar.consultationFee.ToString("F2");
            hdnCalendarId.Value = appCalendarId.ToString();
        }

        protected void updateCalendar()
        {
            btnSave.Text = "Update";
            btnReset.Visible = false;

            if (Convert.ToInt32(txtBalance.Text) > 0)
            {
                ddlDateAvailable.Enabled = false;
                txtFrom.Enabled = false;
                txtTo.Enabled = false;
                ddlBranch.Enabled = false;
                txtConsultationFee.Enabled = false;
            }
        }

        protected void deleteCalendar()
        {
            ddlDateAvailable.Enabled = false;
            txtFrom.Enabled = false;
            txtTo.Enabled = false;
            txtWebQuota.Enabled = false;
            txtOfflineQuota.Enabled = false;
            txtBalance.Enabled = false;
            ddlBranch.Enabled = false;
            txtConsultationFee.Enabled = false;

            btnSave.Text = "Delete";
            btnReset.Visible = false;
        }

        protected void viewPatients(int appCalendarId)
        {
            AppCalendarController appCalendarController = new AppCalendarController();
            DataTable dt = new DataTable();
            dt = appCalendarController.getPatients(appCalendarId);
            grdPatients.DataSource = dt;
            grdPatients.DataBind();
        }

        protected void grdCalendar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grdPatients.Rows[rowIndex];
            HiddenField patient = (HiddenField)row.FindControl("hdnPatientId");
            HiddenField appointment = (HiddenField)row.FindControl("hdnAppointmentId");
            int patientId = Convert.ToInt32(patient.Value);
            int appointmentId = Convert.ToInt32(appointment.Value);
            Response.Redirect("ConsultationUI.aspx?patientID=" + patientId + "&appointmentId=" + appointmentId);
        }
    }
}