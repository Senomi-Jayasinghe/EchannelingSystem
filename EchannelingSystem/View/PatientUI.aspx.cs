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
    public partial class PatientUI1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   //SET DATA TO DROPDOWNS
                getTitleData();
                getBranchData();
                getDistrictData();

                if (Request.QueryString["patientID"] != null)
                {
                    int patientID;
                    if (int.TryParse(Request.QueryString["patientID"], out patientID))
                    {
                        getData(patientID); //GET PATIENT DETAILS BY ID IF UPDATE OR DELETE MODE

                        if (Request.QueryString["mode"] == "U")
                        {
                            updatePatient();//UPDATE
                        }
                        else if (Request.QueryString["mode"] == "D")
                        {
                            deletePatient();//DELETE
                        }
                    }
                }
            }
        }

        protected void txtInitial_TextChanged(object sender, EventArgs e)
        {
            txtFullName.Text = txtInitial.Text + " " + txtLastName.Text;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PatientController patientController = new PatientController();
                Patient patient = new Patient();

                patient.patientTitleID = Convert.ToInt32(ddlTitle.SelectedValue);
                patient.patientInitial = txtInitial.Text;
                patient.patientLname = txtLastName.Text;
                patient.patientFullname = txtFullName.Text;
                patient.patientDOB = Convert.ToDateTime(ddlDateOfBirth.Text);
                patient.patientGender = ddlGender.Text;
                patient.patientNIC = txtNIC.Text;
                patient.patientPassport = txtPassport.Text;
                patient.patientAddress = txtAddress.InnerText;
                patient.patientDistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
                patient.patientEmail = txtEmail.Text;
                patient.patientMobileNo = txtMobileNo.Text;
                patient.patientTelephoneNo = txtTelephoneNo.Text;
                patient.patientGeolocation = txtGeoLocation.Text;
                patient.patientBranchID = Convert.ToInt32(ddlBranch.SelectedValue);

                if (btnSave.Text == "Save")
                {//INSERT
                    patientController.SavePatient(patient);
                    lblPnlMsg.Text = "Save Success";
                }
                else if (btnSave.Text == "Update")
                {//UPDATE
                    patient.patientID = Convert.ToInt32(hdnPatientId.Value);
                    patientController.UpdatePatient(patient);
                    lblPnlMsg.Text = "Update Success";
                }
                else if (btnSave.Text == "Delete")
                {//DELETE
                    patient.patientID = Convert.ToInt32(hdnPatientId.Value);
                    patientController.DeletePatient(patient);
                    lblPnlMsg.Text = "Delete Success";
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
        {//RESET BUTTON
            ddlTitle.SelectedIndex = 0;
            txtInitial.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtInitial.Text = string.Empty;
            ddlDateOfBirth.Text = string.Empty;
            ddlGender.Text = string.Empty;
            txtNIC.Text = string.Empty;
            txtPassport.Text = string.Empty;
            txtAddress.InnerText = string.Empty;
            ddlDistrict.SelectedIndex = 0;
            txtEmail.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtTelephoneNo.Text = string.Empty;
            txtGeoLocation.Text = string.Empty;
            ddlBranch.SelectedIndex = 0;
        }
        protected void getTitleData()
        {   //SET TITLE DATA TO DROP DOWN
            TitleController titleController = new TitleController();
            DataTable dt = new DataTable();
            dt = titleController.GetTitle();

            ddlTitle.DataSource = dt;
            ddlTitle.DataTextField = "title_description";
            ddlTitle.DataValueField = "title_id";
            ddlTitle.DataBind();

            ddlTitle.Items.Insert(0, new ListItem("Select Title", "0"));
        }

        protected void getBranchData()
        {   //SET BRANCH DATA TO DROPDOWN
            BranchController branchController = new BranchController();
            DataTable dt = new DataTable();
            dt = branchController.GetBranch();

            ddlBranch.DataSource = dt;
            ddlBranch.DataTextField = "branch_name";
            ddlBranch.DataValueField = "branch_id";
            ddlBranch.DataBind();

            ddlBranch.Items.Insert(0, new ListItem("Select Branch", "0"));
        }

        protected void getDistrictData()
        {   //SET DISTRICT DATA TO DROPDOWN
            DistrictController districtController = new DistrictController();
            DataTable dt = new DataTable();
            dt = districtController.GetDistrict();

            ddlDistrict.DataSource = dt;
            ddlDistrict.DataTextField = "district_description";
            ddlDistrict.DataValueField = "district_id";
            ddlDistrict.DataBind();

            ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));
        }

        protected void getData(int patientID)
        {   //GET PATIENT DETAILS BY ID FOR UPDATE AND DELETE FUNCTIONS
            PatientController patientController = new PatientController();
            Patient patient = patientController.getPatientByID(patientID);
            if (patient != null)
            {
                ddlTitle.SelectedValue = patient.patientTitleID == null ? "0" : patient.patientTitleID.ToString();
                txtInitial.Text = patient.patientInitial;
                txtLastName.Text = patient.patientLname;
                txtFullName.Text = patient.patientFullname;
                ddlDateOfBirth.Text = patient.patientDOB.ToString("MM/dd/yyyy");
                ddlGender.SelectedValue = patient.patientGender;
                txtNIC.Text = patient.patientNIC;
                txtPassport.Text = patient.patientPassport;
                txtAddress.InnerText = patient.patientAddress;
                ddlDistrict.SelectedValue = patient.patientDistrictID.ToString();
                txtEmail.Text = patient.patientEmail;
                txtMobileNo.Text = patient.patientMobileNo;
                txtTelephoneNo.Text = patient.patientTelephoneNo;
                txtGeoLocation.Text = patient.patientGeolocation;
                ddlBranch.SelectedValue = patient.patientBranchID.ToString();
                hdnPatientId.Value = patient.patientID.ToString();
                btnBack.Visible = true;
            }
        }

        protected void updatePatient()
        {//UPDATE 
            btnSave.Text = "Update";
            btnReset.Visible = false;
        }

        protected void deletePatient()
        {//DISABLE FIELDS FOR DELETE FUNCTION
            ddlTitle.Enabled = false;
            txtInitial.Enabled = false;
            txtLastName.Enabled = false;
            txtFullName.Enabled = false;
            ddlDateOfBirth.Enabled = false;
            ddlGender.Enabled = false;
            txtNIC.Enabled = false;
            txtPassport.Enabled = false;
            txtAddress.Disabled = true;
            ddlDistrict.Enabled = false;
            txtEmail.Enabled = false;
            txtMobileNo.Enabled = false;
            txtTelephoneNo.Enabled = false;
            txtGeoLocation.Enabled = false;
            ddlBranch.Enabled = false;
            //CHANGE SAVE BUTTON TO DELETE
            btnSave.Text = "Delete";
            btnReset.Visible = false;
        }
    }
}