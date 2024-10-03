using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchannelingSystem
{
    public partial class Echanneling : System.Web.UI.MasterPage
    {
        public string roleId { get; set; }
        public string userName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ROLE"] == null)
            {
                Response.Redirect("LoginUI.aspx");
            }
            else
            {
                roleId = Session["USER_ROLE"].ToString(); //Setting session details
                userName = Session["USER_NAME"].ToString();
                hlUserName.Text = "Welcome, " + userName; //The name of the user is displayed in the navbar
            }
        }
    }
}