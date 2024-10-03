using EchannelingSystem.Controller;
using EchannelingSystem.Database;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchannelingSystem.View
{
    public partial class ConsultantUI : System.Web.UI.Page
    {
        List<Qualification> qualificationList = new List<Qualification>();
        List<Specialization> specializationList = new List<Specialization>();
        string EntryUser;
        public string roleId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getTitleData(); //SET DATA TO DROPDOWNS
                getQualificationData();
                getSpecializationData();
                EntryUser = Session["USER_ID"].ToString(); //SET ENTRY USER

                if (Request.QueryString["consultantID"] != null)
                {
                    int consultantID;
                    if (int.TryParse(Request.QueryString["consultantID"], out consultantID))
                    {
                        getData(consultantID);

                        if (Request.QueryString["mode"] == "U")
                        {
                            updateConsultant(); //UPDATE
                        }
                        else if (Request.QueryString["mode"] == "D")
                        {
                            deleteConsultant(); //DELETE
                        }
                    }
                }
            }
            else
            {
                if (ViewState["QualificationData"] != null)
                {   //SET SELECTED QUALIFICATIONS TO LIST
                    qualificationList = (List<Qualification>)ViewState["QualificationData"];
                }

                if (ViewState["SpecializationData"] != null)
                {   //SET SELECTED SPECIALIZATIONS TO LIST
                    specializationList = (List<Specialization>)ViewState["SpecializationData"];
                }
            }
        }
        protected void txtInitial_TextChanged(object sender, EventArgs e)
        {   //CONCATENATE INITIAL AND LASTNAME
            txtFullName.Text = txtInitial.Text + " " + txtLastName.Text;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ConsultantController consultantController = new ConsultantController();
                Consultant consultant = new Consultant();
                consultant.consultantTitle = Convert.ToInt32(ddlTitle.SelectedValue);
                consultant.consultantInitial = txtInitial.Text;
                consultant.consultantLname = txtLastName.Text;
                consultant.consultantFullname = txtFullName.Text;
                consultant.consultantDOB = Convert.ToDateTime(ddlDateOfBirth.Text);
                consultant.consultantGender = ddlGender.SelectedValue;
                consultant.consultantRegisterID = Convert.ToInt32(txtRegisterID.Text);
                consultant.consultantAddress = txtAddress.InnerText;
                consultant.consultantContact1 = txtContactNumber1.Text;
                consultant.consultantContact2 = txtContactNumber2.Text;
                consultant.consultantEmail = txtEmail.Text;
                consultant.consultantHospital = txtHospital.Text;
                consultant.entryUser = Convert.ToInt32(Session["USER_ID"]);
                consultant.entryDate = DateTime.Now;

                if (btnSave.Text == "Save")
                {   //INSERT
                    UserLogin userLogin = new UserLogin();
                    userLogin.userEmail = txtEmail.Text;
                    userLogin.userPassword = generatePassword();
                    consultantController.SaveConsultant(consultant, qualificationList, specializationList, userLogin);
                    lblPnlMsg.Text = "Save Success \nUserName:" + userLogin.userEmail + "\nPassword:" + userLogin.userPassword;
                }
                else if (btnSave.Text == "Update")
                {   //UPDATE
                    consultant.consultantID = Convert.ToInt32(hdnConsultantId.Value);
                    consultantController.UpdateConsultant(consultant, qualificationList, specializationList);
                    lblPnlMsg.Text = "Update Success";
                }
                else if (btnSave.Text == "Delete")
                {   //DELETE
                    consultant.consultantID = Convert.ToInt32(hdnConsultantId.Value);
                    consultantController.DeleteConsultant(consultant, qualificationList, specializationList);
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
        {   //RESET FIELDS TO BLANK
            ddlTitle.SelectedIndex = 0;
            txtInitial.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtInitial.Text = string.Empty;
            ddlDateOfBirth.Text = string.Empty;
            ddlGender.Text = string.Empty;
            txtRegisterID.Text = string.Empty;
            txtAddress.InnerText = string.Empty;
            txtContactNumber1.Text = string.Empty;
            txtContactNumber2.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtHospital.Text = string.Empty;
            ddlQualification.SelectedIndex = 0;
            ddlSpecialization.SelectedIndex = 0;
        }

        protected void ddlQualification_SelectedIndexChanged(object sender, EventArgs e)
        {   //SET SELECTED QUALIFICATION TO VIEWSTATE WHICH WILL THEN BE SET TO QUALIFICATION LIST ON PAGE LOAD
            if (ddlQualification.SelectedValue != "0")
            {
                Qualification qualification = new Qualification();
                qualification.qualificationID = Convert.ToInt32(ddlQualification.SelectedValue);
                qualification.qualificationDescription = ddlQualification.SelectedItem.Text;
                qualificationList.Add(qualification);
                ViewState["QualificationData"] = qualificationList;

                grdQualification.DataSource = qualificationList;
                grdQualification.DataBind();
            }
        }

        protected void ddlSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {   /*SET SELECTED SPECIALIZATION TO VIEWSTATE WHICH WILL THEN BE SET TO SPECIALIZATION LIST ON
            PAGE LOAD*/
            if (ddlSpecialization.SelectedValue != "0")
            {
                Specialization specialization = new Specialization();
                specialization.specializationID = Convert.ToInt32(ddlSpecialization.SelectedValue);
                specialization.specializationDescription = ddlSpecialization.SelectedItem.Text;
                specializationList.Add(specialization);
                ViewState["SpecializationData"] = specializationList;

                grdSpecialization.DataSource = specializationList;
                grdSpecialization.DataBind();
            }
        }

        protected void grdQualification_RowCommand(object sender, GridViewCommandEventArgs e)
        {   //REMOVING A QUALIFICATION FROM LIST
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                List<Qualification> qualificationData = (List<Qualification>)ViewState["QualificationData"];
                qualificationData.RemoveAt(rowIndex);
                grdQualification.DataSource = qualificationData;
                grdQualification.DataBind();
            }
        }

        protected void grdSpecialization_RowCommand(object sender, GridViewCommandEventArgs e)
        {   //REMOVING A SPECIALIZATION FROM LIST
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                List<Specialization> specializationData = (List<Specialization>)ViewState["SpecializationData"];
                specializationData.RemoveAt(rowIndex);
                grdSpecialization.DataSource = specializationData;
                grdSpecialization.DataBind();
            }
        }

        public void getQualificationData()
        {   //SET QUALIFICATION TO DROPDOWN
            try
            {
                QualificationController qualificationController = new QualificationController();
                DataTable dt = new DataTable();
                dt = qualificationController.getQualification();

                ddlQualification.DataSource = dt;
                ddlQualification.DataTextField = "qualification_description";
                ddlQualification.DataValueField = "qualification_id";
                ddlQualification.DataBind();

                ddlQualification.Items.Insert(0, new ListItem("Select Qualification", "0"));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void getSpecializationData()
        {   //SET SPECIALIZATION DATA TO DROPDOWN
            try
            {
                SpecializationController specializationController = new SpecializationController();
                DataTable dt = new DataTable();
                dt = specializationController.getSpecialization();

                ddlSpecialization.DataSource = dt;
                ddlSpecialization.DataTextField = "specialization_description";
                ddlSpecialization.DataValueField = "specialization_id";
                ddlSpecialization.DataBind();

                ddlSpecialization.Items.Insert(0, new ListItem("Select Specialization", "0"));
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void getTitleData()
        {   //SET TITLE DATA TO DROPDOWN
            TitleController titleController = new TitleController();
            DataTable dt = new DataTable();
            dt = titleController.GetTitle();

            ddlTitle.DataSource = dt;
            ddlTitle.DataTextField = "title_description";
            ddlTitle.DataValueField = "title_id";
            ddlTitle.DataBind();

            ddlTitle.Items.Insert(0, new ListItem("Select Title", "0"));
        }

        protected void getData(int consultantID)
        {   //GET CONSULTANT DATA FOR A CONSULTANT ID FOR DELETE AND UPDATE FUNCTIONS
            ConsultantController consultantController = new ConsultantController();
            (Consultant consultant, List<Specialization> specializationList, List<Qualification> qualificationList) =
                consultantController.getConsultantByID(consultantID);
            //DISPLAY DATA IN THE FORM
            ddlTitle.SelectedValue = consultant.consultantTitle.ToString();
            txtInitial.Text = consultant.consultantInitial;
            txtLastName.Text = consultant.consultantLname;
            txtFullName.Text = consultant.consultantFullname;
            ddlDateOfBirth.Text = consultant.consultantDOB.ToString("MM/dd/yyyy");
            ddlGender.SelectedValue = consultant.consultantGender;
            txtRegisterID.Text = consultant.consultantRegisterID.ToString();
            txtAddress.InnerText = consultant.consultantAddress;
            txtContactNumber1.Text = consultant.consultantContact1;
            txtContactNumber2.Text = consultant.consultantContact2;
            txtEmail.Text = consultant.consultantEmail;
            txtHospital.Text = consultant.consultantHospital;

            ViewState["SpecializationData"] = specializationList;
            grdSpecialization.DataSource = specializationList;
            grdSpecialization.DataBind();

            ViewState["QualificationData"] = qualificationList;
            grdQualification.DataSource = qualificationList;
            grdQualification.DataBind();

            hdnConsultantId.Value = consultant.consultantID.ToString();
            btnBack.Visible = true;
        }

        protected void updateConsultant()
        {   //CHANGE SAVE BUTTON TO UPDATE
            btnSave.Text = "Update";
            btnReset.Visible = false;
        }

        protected void deleteConsultant()
        {   //DISABLE TEXT FIELDS AND DROPDOWNS
            ddlTitle.Enabled = false;
            txtInitial.Enabled = false;
            txtLastName.Enabled = false;
            txtFullName.Enabled = false;
            ddlDateOfBirth.Enabled = false;
            ddlGender.Enabled = false;
            txtRegisterID.Enabled = false;
            txtAddress.Disabled = true;
            txtContactNumber1.Enabled = false;
            txtContactNumber2.Enabled = false;
            txtEmail.Enabled = false;
            txtHospital.Enabled = false;
            ddlQualification.Enabled = false;
            ddlSpecialization.Enabled = false;

            foreach (GridViewRow row in grdSpecialization.Rows)
            {
                Button btnDelete = row.FindControl("btnDelete") as Button;
                btnDelete.Visible = false;
            }
            foreach (GridViewRow row in grdQualification.Rows)
            {
                Button btnDelete = row.FindControl("btnDelete") as Button;
                btnDelete.Visible = false;
            }
            btnSave.Text = "Delete";
            btnReset.Visible = false;
        }

        protected static string generatePassword()
        {   //GENERATE NEW LOGIN CREDENTIALS
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+[]{}|;:,.<>?";
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                password.Append(chars[random.Next(chars.Length)]);
            }

            return password.ToString();
        }
    }
}