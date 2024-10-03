using EchannelingSystem.Controller;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchannelingSystem.View
{
    public partial class AppointmentUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            int appid = Convert.ToInt32(Request.QueryString["id"]);
            getAppointmentDetails(appid);
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            int patientid = Convert.ToInt32(Session["USER_ID"]);
            // Response.Redirect("PaymentUI.aspx");
            AppointmentController appointmentController = new AppointmentController();
            Appointment appointment = new Appointment();
            appointment.appCalendarID = Convert.ToInt32(hdnAppCalendarId.Value);
            appointment.consultantID = Convert.ToInt32(hdnConsultantid.Value);
            appointment.patientID = patientid;
            appointment.appointmentStatus = "Booked";
            appointment.appointmentSeq = getAppointmentSequence(Convert.ToInt32(hdnAppCalendarId.Value));
            appointment.paymentID = 1; //for now
            appointment.entryDate = DateTime.Now;
            appointment.entryUser = patientid;
            appointmentController.bookAppointment(appointment);

            Response.Redirect("PaymentUI.aspx?appointmentSeq=" + appointment.appointmentSeq + "&appCalendarID=" + appointment.appCalendarID);
        }

        protected void getAppointmentDetails(int appid)
        {
            AppointmentController appointmentController = new AppointmentController();
            DataTable dt = new DataTable();
            dt = appointmentController.getAppointmentData(appid);

            foreach (DataRow dr in dt.Rows)
            {
                txtConsultantName.Text = dr["consultant_fullname"].ToString();
                hdnConsultantid.Value = dr["consultant_id"].ToString();
                ddlDateAvailable.Text = Convert.ToDateTime(dr["date"]).ToString("MM/dd/yyyy");
                txtFrom.Text = dr["from_time"].ToString();
                txtTo.Text = dr["to_time"].ToString();
                txtBranch.Text = dr["branch_name"].ToString();
                txtBalance.Text = dr["balance"].ToString();
                txtConsultationFee.Text = Convert.ToDecimal(dr["consultation_fee"]).ToString("F2");
                hdnAppCalendarId.Value = appid.ToString();
            }
        }

        protected int getAppointmentSequence(int appId)
        {
            AppointmentController appointmentController = new AppointmentController ();
            int appseq = appointmentController.appointmentSequence(appId);
            return appseq;
        }
               
    }
}