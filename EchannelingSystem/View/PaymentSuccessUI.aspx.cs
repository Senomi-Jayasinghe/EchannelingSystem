using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchannelingSystem.View
{
    public partial class PaymentSuccessUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["appseq"] != null)
            {
                int appseq;
                if (int.TryParse(Request.QueryString["appseq"], out appseq))
                {
                    lblSuccesss.Text = "Payment Successful. Appointment Sequence: " + appseq;
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AppCalendarSearchUI.aspx");
        }
    }
}