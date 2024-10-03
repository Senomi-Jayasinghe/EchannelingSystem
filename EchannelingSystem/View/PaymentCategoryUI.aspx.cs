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
    public partial class PaymentCategoryUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getDataFromDatabase(); //GET DATA FROM DB TO GRID
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PaymentCategoryController paymentCategoryController = new PaymentCategoryController();
                PaymentCategory paymentCategory = new PaymentCategory();

                paymentCategory.categoryDescription = txtPaymentCategory.Text;

                if (btnSave.Text == "Save")
                {//SAVE
                    paymentCategoryController.SavePaymentCategory(paymentCategory);
                    lblPnlMsg.Text = "Save Success";
                }

                else if (btnSave.Text == "Update")
                {//GET SELECTED ID AND UPDATE
                    paymentCategory.paymentCategoryID = Convert.ToInt32(hdnPaymentCategoryId.Value);
                    paymentCategoryController.UpdatePaymentCategory(paymentCategory);
                    lblPnlMsg.Text = "Update Success";
                }
                else if (btnSave.Text == "Delete")
                {//GET SELECTED ID AND DELETE
                    paymentCategory.paymentCategoryID = Convert.ToInt32(hdnPaymentCategoryId.Value);
                    paymentCategoryController.DeletePaymentCategory(paymentCategory);
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
            {//GET DATA FROM DB
                PaymentCategoryController paymentCategoryController = new PaymentCategoryController();
                DataTable dt = new DataTable();
                dt = paymentCategoryController.getPaymentCategory();
                //BIND DATA TO GRID
                grdPaymentCategory.DataSource = dt;
                grdPaymentCategory.DataBind();
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {//RESET FIELDS TO EMPTY
            txtPaymentCategory.Text = string.Empty;
        }

        protected void grdPaymentCategory_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {//UPDATE
            HiddenField field = (HiddenField)grdPaymentCategory.Rows[e.NewSelectedIndex].FindControl("hdnGrdPaymentCategoryId");
            PaymentCategoryController paymentCategoryController = new PaymentCategoryController();
            PaymentCategory paymentCategory = paymentCategoryController.getPaymentCategoryByID(Convert.ToInt32(field.Value));
            hdnPaymentCategoryId.Value = field.Value;
            txtPaymentCategory.Text = paymentCategory.categoryDescription;//FILL FORM WITH DATA

            btnSave.Text = "Update";//CHANGE SAVE BUTTON TO UPDATE
            btnReset.Visible = false;
        }

        protected void grdPaymentCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {//DELETE
            HiddenField field = (HiddenField)grdPaymentCategory.Rows[e.RowIndex].FindControl("hdnGrdPaymentCategoryId");
            PaymentCategoryController paymentCategoryController = new PaymentCategoryController();
            PaymentCategory paymentCategory = paymentCategoryController.getPaymentCategoryByID(Convert.ToInt32(field.Value));
            hdnPaymentCategoryId.Value = field.Value;
            txtPaymentCategory.Text = paymentCategory.categoryDescription;//FILL FORM WITH DATA

            btnSave.Text = "Delete";//CHANGE SAVE TO DELETE BUTTON
            btnReset.Visible = false;

            txtPaymentCategory.Enabled = false;//DISABLE ALL FIELDS
        }
    }
}