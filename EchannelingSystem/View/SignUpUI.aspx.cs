using EchannelingSystem.Controller;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchannelingSystem.View
{
    public partial class SignUpUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (IsEmailExist()) //Check if Email Exists
            {
                lblMessage.Text = "Email Already Exists";
            }
            else
            {
                if (txtPassword.Text == txtConfirmPassword.Text) 
                { //If email doesn't exist, check if entered password is correct and register patient
                    EnterDetails();
                    Response.Redirect("HomeUI.aspx");
                }
                else
                {
                    lblMessage.Text = "Passwords do not match. Please try again";
                }
            }
        }

        protected bool IsEmailExist() //Check if email exists
        {
            LoginController loginController = new LoginController();
            string Email = txtEmail.Text;
            return loginController.IsExistEmail(Email); 
        }

        protected void EnterDetails() //Register Patient
        {
            Patient patient = new Patient();
            patient.patientInitial = txtInitial.Text;
            patient.patientLname = txtLastName.Text;
            patient.patientEmail = txtEmail.Text;
            UserLogin userLogin = new UserLogin();
            userLogin.userEmail = txtEmail.Text;
            userLogin.userPassword = txtPassword.Text;
            userLogin.userRole = 1;
            LoginController loginController = new LoginController();
            loginController.EnterDetails(patient, userLogin);
        }
    }
}