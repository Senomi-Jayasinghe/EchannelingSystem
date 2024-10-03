using EchannelingSystem.Controller;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchannelingSystem.View
{
    public partial class PaymentUI : System.Web.UI.Page
    {
        protected string payhereurl { get; set; }
        protected string currency { get; set; }
        protected string amount { get; set; }
        protected string amountDisplay { get; set; }
        protected string order_id { get; set; }
        protected string merchant_id { get; set; }
        protected string return_url { get; set; }
        protected string cancel_url { get; set; }
        protected string notify_url { get; set; }
        protected string first_name { get; set; }
        protected string last_name { get; set; }
        protected string email { get; set; }
        protected string phone { get; set; }
        protected string address { get; set; }
        protected string city { get; set; }
        protected string country { get; set; }
        protected string hash { get; set; }
        int branchid;
        int appointmentid;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int appointmentSeq = Convert.ToInt32(Request.QueryString["appointmentSeq"]);
                int appCalendarID = Convert.ToInt32(Request.QueryString["appCalendarID"]);
                this.payhereurl = WebConfigurationManager.AppSettings["PAY_HERE_URL"].ToString();
                this.merchant_id = WebConfigurationManager.AppSettings["PAY_HERE_MERCHANT_ID"].ToString();
                this.order_id = Request.QueryString["appointmentSeq"];
                this.return_url = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, "/") + "View/PaymentSuccessUI.aspx?appseq=" + appointmentSeq;
                this.cancel_url = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, "/") + "View/PaymentSuccessUI.aspx?appseq=" + appointmentSeq;
                this.notify_url = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, "/") + "View/PaymentSuccessUI.aspx?appseq=" + appointmentSeq;

                PaymentController paymentController = new PaymentController();
                DataTable dataTable = new DataTable();
                dataTable = paymentController.getPaymentInfo(appointmentSeq, appCalendarID);

                foreach (DataRow dr in dataTable.Rows)
                {
                    appointmentid = Convert.ToInt32(dr["appointment_id"]);
                    branchid = Convert.ToInt32(dr["patient_branch_id"]);
                    this.first_name = dr["patient_initial"].ToString();
                    this.last_name = dr["patient_lname"].ToString();
                    this.email = dr["patient_email"].ToString();
                    this.phone = dr["patient_mobileno"].ToString();
                    this.address = dr["patient_address"].ToString();
                    this.city = dr["district_description"].ToString();
                    this.country = "srilanka";

                    this.amount = Convert.ToDecimal(dr["consultation_fee"]).ToString("F2");
                    this.amountDisplay = Convert.ToDecimal(dr["consultation_fee"]).ToString("F2");
                }

                this.currency = "LKR";//Currency Code (LKR/USD)   
                PaymentDetails paymentDetails = new PaymentDetails();
                paymentDetails.paymentBranchID = branchid;
                paymentDetails.paymentCategoryID = 1;
                paymentDetails.paymentAmount = Convert.ToDecimal(this.amount);
                paymentDetails.paymentTypeID = 1;
                paymentDetails.paymentStatus = "Success";
                paymentDetails.entryUser = Convert.ToInt32(Session["USER_ID"]);
                DateTime entryDate = DateTime.Now;
                paymentDetails.entryDate = entryDate.ToString("MM/dd/yyyy"); ;

                enterPaymentdetails(paymentDetails, appointmentid);

                string merchant_secret = MD5Hash(WebConfigurationManager.AppSettings["PAY_HERE_SECRET"].ToString()).ToUpper();
                string local_md5sig = MD5Hash(merchant_id + order_id + Convert.ToDouble(amount).ToString("####0.00") + this.currency + merchant_secret).ToUpper();
                this.hash = local_md5sig;
            }
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public void enterPaymentdetails(PaymentDetails paymentDetails, int appointmentid)
        {
            PaymentController paymentController = new PaymentController();
            paymentController.enterPaymentdetails(paymentDetails, appointmentid);
        }
    }
}