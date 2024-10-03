using EchannelingSystem.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchannelingSystem.View
{
    public partial class UpdatePassword1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            if(getPassword()) //Get Old password
            {
                if (txtNewPassword.Text == txtConfirm.Text)
                {
                    updatePassword(); //Update Password if Old Password matches with password entered
                    pnlMsg.Visible = true;
                    pnlMsg.CssClass = "alert alert-success";
                    lblPnlMsg.Text = "Update Successful";
                }
                else
                {
                    pnlMsg.Visible = true;
                    pnlMsg.CssClass = "alert alert-danger";
                    lblPnlMsg.Text = "Passwords do not match. Please try again";
                }
            }
            else
            {
                pnlMsg.Visible = true;
                pnlMsg.CssClass = "alert alert-danger";
                lblPnlMsg.Text = "Incorrect Password Entered";
            }
        }

        protected bool getPassword() //Get Old Password
        {
            LoginController loginController = new LoginController();
            int UserID = Convert.ToInt32(Session["USER_ID"]);
            int RoleID = Convert.ToInt32(Session["USER_ROLE"]);
            string OldPassword = txtOldPassword.Text;
            return loginController.getOldPassword(UserID,RoleID,OldPassword);
        }

        protected void updatePassword() //Update Password
        {
            LoginController loginController = new LoginController();
            int UserID = Convert.ToInt32(Session["USER_ID"]);
            int RoleID = Convert.ToInt32(Session["USER_ROLE"]);
            string NewPassword = txtNewPassword.Text;
            loginController.UpdatePassword(NewPassword, UserID, RoleID);
        }
    }
}