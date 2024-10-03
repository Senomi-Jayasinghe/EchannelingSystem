using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchannelingSystem.View
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int RoleID = Convert.ToInt32(Session["USER_ROLE"]);
            int UserID = Convert.ToInt32(Session["USER_ID"]);
            if (RoleID == 1)
            {
                Response.Redirect("PatientUI.aspx?patientID=" + UserID + "&mode=U");
            }
            else if (RoleID == 2)
            {
                Response.Redirect("ConsultantUI.aspx?ConsultantID=" + UserID + "&mode=U");
            }
            else if (RoleID == 3)
            {
                Response.Redirect("AdminUI.aspx?AdminID=" + UserID + "&mode=U");
            }
        }
    }
}