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
    public partial class LoginUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool isExistUser;
            LoginController loginController = new LoginController();
            UserLogin userLogin = new UserLogin();
            userLogin.userEmail = txtEmail.Text;
            userLogin.userPassword = txtPassword.Text;
            isExistUser = loginController.SearchUser(userLogin); // Check if User Exists in System

            if (isExistUser) //if the user exists...
            {
                DataTable dt = loginController.getUser(userLogin); //Get User Details using credentials
                Session["USER_ROLE"] = dt.Rows[0]["user_role"];
                Session["USER_NAME"] = dt.Rows[0]["user_name"];
                Session["USER_ID"] = dt.Rows[0]["user_reference_id"];

                //Check User_Role and direct them accordingly 
                if (Convert.ToInt32(Session["USER_ROLE"]) == 1)
                {
                    Response.Redirect("HomeUI.aspx");
                }
                else if (Convert.ToInt32(Session["USER_ROLE"]) == 2)
                {
                    Response.Redirect("ConsultantHomeUI.aspx");
                }
                else if (Convert.ToInt32(Session["USER_ROLE"]) == 3)
                {
                    Response.Redirect("AdminHomeUI.aspx");
                }
            }
            else
            {
                errMsg.Visible = true;

            }
            //Session["USER_ROLE"] = "2";
            //Session["USER_NAME"] = "test";
            //Session["USER_ID"] = "9";
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUpUI.aspx"); //Redirect to Signup Page when Sign Up button is clicked
        }

        protected void btnForgotPsw_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgetPassword.aspx"); //Redirect to Forgot Password Page when Forgot Password button is clicked
        }
    }
}