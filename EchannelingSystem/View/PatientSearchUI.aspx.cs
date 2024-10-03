using EchannelingSystem.Controller;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchannelingSystem.View
{
    public partial class PatientSearchUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                PatientController patientController = new PatientController();
                Patient patient = new Patient();
                patient.patientInitial = txtInitial.Text;
                patient.patientLname = txtLastName.Text;
                patient.patientNIC = txtNIC.Text;
                patient.patientPassport = txtPassport.Text;
                patient.patientEmail = txtEmail.Text;
                patient.patientMobileNo = txtMobileNo.Text;
                patient.patientTelephoneNo = txtTelephoneNo.Text;

                DataTable dt = new DataTable();

                dt = patientController.getPatient(patient);

                grdPatient.DataSource = dt;
                grdPatient.DataBind();
            }

            catch (Exception)
            {
                throw;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtInitial.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtNIC.Text = string.Empty;
            txtPassport.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtTelephoneNo.Text = string.Empty;

        }

        protected void grdPatient_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            HiddenField field = (HiddenField)grdPatient.Rows[e.NewSelectedIndex].FindControl("hdnGrdPatientId");
            Patient patient = new Patient();
            hdnPatientId.Value = field.Value;
            patient.patientID = Convert.ToInt32(field.Value);
            Response.Redirect("PatientUI.aspx?patientID=" + patient.patientID + "&mode=U");
        }

        protected void grdPatient_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HiddenField field = (HiddenField)grdPatient.Rows[e.RowIndex].FindControl("hdnGrdPatientId");
            Patient patient = new Patient();
            hdnPatientId.Value = field.Value;
            patient.patientID = Convert.ToInt32(field.Value);
            Response.Redirect("PatientUI.aspx?patientID=" + patient.patientID + "&mode=D");
        }
    }
}