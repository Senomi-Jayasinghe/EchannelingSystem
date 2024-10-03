using EchannelingSystem.Controller;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchannelingSystem.View
{
    public partial class AdminUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ROLE"].ToString() != "3")
            {
                Response.Redirect("LoginUI.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    getTitleData(); //GET TITLE DATA
                    getDataFromDatabase(); //GET DATA OF ADMINS FOR GRID

                    if (Request.QueryString["AdminID"] != null)
                    {
                        int adminID;
                        if (int.TryParse(Request.QueryString["AdminID"], out adminID))
                        {
                            getData(adminID); //GET ADMIN DETAILS FOR AN ADMIN ID FOR UPDATE AND DELETE FUNCTIONS

                            if (Request.QueryString["mode"] == "U")
                            {
                                updateAdmin();  //UPDATE
                            }
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
                AdminController adminController = new AdminController();

                Admin admin = new Admin();
                admin.adminTitleID = Convert.ToInt32(ddlTitle.SelectedValue);
                admin.adminInitial = txtInitial.Text;
                admin.adminLname = txtLastName.Text;
                admin.adminFullname = txtFullName.Text;
                admin.adminDOB = Convert.ToDateTime(ddlDateOfBirth.Text);
                admin.adminNIC = txtNIC.Text;
                admin.adminPassport = txtPassport.Text;
                admin.adminEmail = txtEmail.Text;
                admin.adminMobileNo = txtMobileNo.Text;
                admin.adminTelephoneNo = txtTelephoneNo.Text;
                admin.entryUser = Convert.ToInt32(Session["USER_ID"]);
                admin.entryDate = DateTime.Now;

                if (btnSave.Text == "Save")
                {   //INSERT
                    UserLogin userLogin = new UserLogin();
                    userLogin.userEmail = txtEmail.Text;
                    userLogin.userPassword = generatePassword();
                    adminController.SaveAdmin(admin, userLogin);
                    //DISPLAY NEW CREDENTIALS
                    lblPnlMsg.Text = "Save Success </br>UserName:" + userLogin.userEmail + "</br>Password:" + userLogin.userPassword;
                }
                else if (btnSave.Text == "Update")
                {//UPDATE
                    admin.adminID = Convert.ToInt32(hdnAdminId.Value);
                    adminController.UpdateAdmin(admin);
                    lblPnlMsg.Text = "Update Success";
                }
                else if (btnSave.Text == "Delete")
                {//DELETE
                    admin.adminID = Convert.ToInt32(hdnAdminId.Value);
                    adminController.DeleteAdmin(admin);
                    lblPnlMsg.Text = "Delete Success";
                }
                getDataFromDatabase();//UPDATE GRID AFTER UPDATE,DELETE, AND INSERT

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

        protected void getDataFromDatabase()
        {//GET ADMIN DETAILS AND BIND TO GRID
            try
            {
                AdminController adminController = new AdminController();
                DataTable dt = new DataTable();
                dt = adminController.getAdmin();

                grdAdmin.DataSource = dt;
                grdAdmin.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void getTitleData()
        {//GET TITLE DATA
            TitleController titleController = new TitleController();
            DataTable dt = new DataTable();
            dt = titleController.GetTitle();

            ddlTitle.DataSource = dt;
            ddlTitle.DataTextField = "title_description";
            ddlTitle.DataValueField = "title_id";
            ddlTitle.DataBind();

            ddlTitle.Items.Insert(0, new ListItem("Select Title", "0"));
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {//RESET FILEDS
            ddlTitle.SelectedIndex = 0;
            txtInitial.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtFullName.Text = string.Empty;
            ddlDateOfBirth.Text = string.Empty;
            txtNIC.Text = string.Empty;
            txtPassport.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtTelephoneNo.Text = string.Empty;
        }

        protected void grdAdmin_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {//WHEN DELETING AN ADMIN FROM GRID
            HiddenField field = (HiddenField)grdAdmin.Rows[e.RowIndex].FindControl("hdnGrdAdminId");
            getData(Convert.ToInt32(field.Value));
            hdnAdminId.Value = field.Value;

            btnSave.Text = "Delete";
            btnReset.Visible = false;

            ddlTitle.Enabled = false;
            txtInitial.Enabled = false;
            txtLastName.Enabled = false;
            txtFullName.Enabled = false;
            ddlDateOfBirth.Enabled = false;
            txtNIC.Enabled = false;
            txtPassport.Enabled = false;
            txtEmail.Enabled = false;
            txtMobileNo.Enabled = false;
            txtTelephoneNo.Enabled = false;
        }

        protected void grdAdmin_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {//WHEN UPDATING ADMIN FROM GRID
            HiddenField field = (HiddenField)grdAdmin.Rows[e.NewSelectedIndex].FindControl("hdnGrdAdminId");
            getData(Convert.ToInt32(field.Value));

            btnSave.Text = "Update";
            btnReset.Visible = false;
        }

        protected void getData(int adminId)
        {//GET DATA OF ADMIN BY ADMIN ID
            AdminController adminController = new AdminController();
            Admin admin = adminController.getAdminByID(adminId);

            hdnAdminId.Value = adminId.ToString();

            ddlTitle.SelectedIndex = admin.adminTitleID;
            txtInitial.Text = admin.adminInitial;
            txtLastName.Text = admin.adminLname;
            txtFullName.Text = admin.adminFullname;
            ddlDateOfBirth.Text = admin.adminDOB.ToString("MM/dd/yyyy");
            txtNIC.Text = admin.adminNIC;
            txtPassport.Text = admin.adminPassport;
            txtEmail.Text = admin.adminEmail;
            txtMobileNo.Text = admin.adminMobileNo;
            txtTelephoneNo.Text = admin.adminTelephoneNo;
        }

        protected void updateAdmin()
        {//UPDATE
            btnSave.Text = "Update";
            btnReset.Visible = false;
            grdAdmin.Visible = false;
        }

        protected static string generatePassword()
        {//GENERATE NEW CREDENTIALS
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