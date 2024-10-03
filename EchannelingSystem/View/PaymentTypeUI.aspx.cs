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
    public partial class PaymentTypeUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getDataFromDatabase();//GET DATA FROM DB TO GRID
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PaymentTypeController paymentTypeController = new PaymentTypeController();
                PaymentType paymentType = new PaymentType();

                paymentType.paymentTypeDescription = txtPaymentType.Text;

                if (btnSave.Text == "Save")
                {//SAVE
                    paymentTypeController.SavePaymentType(paymentType);
                    lblPnlMsg.Text = "Save Success";
                }
                else if (btnSave.Text == "Update")
                {//GET SELECTED ID AND UPDATE
                    paymentType.paymentTypeID = Convert.ToInt32(hdnPaymentTypeId.Value);
                    paymentTypeController.UpdatePaymentType(paymentType);
                    lblPnlMsg.Text = "Update Success";

                }
                else if (btnSave.Text == "Delete")
                {//GET SELECTED ID AND DELETE
                    paymentType.paymentTypeID = Convert.ToInt32(hdnPaymentTypeId.Value);
                    paymentTypeController.DeletePaymentType(paymentType);
                    lblPnlMsg.Text = "Delete Success";
                }
                getDataFromDatabase();//UPDATE GRID WITH CHANGED DATA

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

        public void getDataFromDatabase()
        {
            try
            {
                PaymentTypeController paymentTypeController = new PaymentTypeController();
                DataTable dt = new DataTable();
                dt = paymentTypeController.getPaymentType();
                //GET DATA FROM DB AND BIND TO GRID
                grdPaymentType.DataSource = dt;
                grdPaymentType.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtPaymentType.Text = string.Empty;//RESET FIELDS TO EMPTY
        }

        protected void grdPaymentType_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {//UPDATE
            HiddenField field = (HiddenField)grdPaymentType.Rows[e.NewSelectedIndex].FindControl("hdnGrdPaymentTypeId");
            PaymentTypeController paymentTypeController = new PaymentTypeController();
            PaymentType paymentType = paymentTypeController.getPaymentTypeByID(Convert.ToInt32(field.Value));
            hdnPaymentTypeId.Value = field.Value;
            txtPaymentType.Text = paymentType.paymentTypeDescription;//FILL FORM WITH DATA

            btnSave.Text = "Update";//CHANGE SAVE TO UPDATE BUTTON
            btnReset.Visible = false;
        }

        protected void grdPaymentType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {//DELETE
            HiddenField field = (HiddenField)grdPaymentType.Rows[e.RowIndex].FindControl("hdnGrdPaymentTypeId");
            PaymentTypeController paymentTypeController = new PaymentTypeController();
            PaymentType paymentType = paymentTypeController.getPaymentTypeByID(Convert.ToInt32(field.Value));
            hdnPaymentTypeId.Value = field.Value;
            txtPaymentType.Text = paymentType.paymentTypeDescription;

            btnSave.Text = "Delete";//CHANGE SAVE TO DELETE BUTTON
            btnReset.Visible = false;

            txtPaymentType.Enabled = false;//DISABLE FIELDS
        }
    }
}