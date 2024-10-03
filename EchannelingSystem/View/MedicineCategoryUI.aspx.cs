using EchannelingSystem.Controller;
using EchannelingSystem.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchannelingSystem.View
{
    public partial class MedicineCategoryUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getDataFromDatabase();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MedicineCategoryController medicineCategoryController = new MedicineCategoryController();
                MedicineCategory medicineCategory = new MedicineCategory();

                medicineCategory.medicineCategoryDescription = txtMedCategory.Text;

                if (btnSave.Text == "Save")
                {
                    medicineCategoryController.SaveMedicineCategory(medicineCategory);
                    lblPnlMsg.Text = "Save Success";
                }

                else if (btnSave.Text == "Update")
                {
                    medicineCategory.medicineCategoryID = Convert.ToInt32(hdnMedicineCategoryId.Value);
                    medicineCategoryController.UpdateMedicineCategory(medicineCategory);
                    lblPnlMsg.Text = "Update Success";
                }
                else if (btnSave.Text == "Delete")
                {
                    medicineCategory.medicineCategoryID = Convert.ToInt32(hdnMedicineCategoryId.Value);
                    medicineCategoryController.DeleteMedicineCategory(medicineCategory);
                    lblPnlMsg.Text = "Update Success";
                }
                getDataFromDatabase();

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
        {
            try
            {
                MedicineCategoryController medicineCategoryController = new MedicineCategoryController();
                DataTable dt = new DataTable();
                dt = medicineCategoryController.getMedicineCategory();

                grdMedicineCategory.DataSource = dt;
                grdMedicineCategory.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtMedCategory.Text = string.Empty;
        }

        protected void grdMedCategory_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            HiddenField field = (HiddenField)grdMedicineCategory.Rows[e.NewSelectedIndex].FindControl("hdnGrdMedicineCategoryId");
            MedicineCategoryController medicineCategoryController = new MedicineCategoryController();
            MedicineCategory medicineCategory = medicineCategoryController.getMedicineCategoryByID(Convert.ToInt32(field.Value));
            hdnMedicineCategoryId.Value = field.Value;
            txtMedCategory.Text = medicineCategory.medicineCategoryDescription;

            btnSave.Text = "Update";
            btnReset.Visible = false;
        }

        protected void grdMedCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HiddenField field = (HiddenField)grdMedicineCategory.Rows[e.RowIndex].FindControl("hdnGrdMedicineCategoryId");
            MedicineCategoryController medicineCategoryController = new MedicineCategoryController();
            MedicineCategory medicineCategory = medicineCategoryController.getMedicineCategoryByID(Convert.ToInt32(field.Value));
            hdnMedicineCategoryId.Value = field.Value;
            txtMedCategory.Text = medicineCategory.medicineCategoryDescription;

            btnSave.Text = "Delete";
            btnReset.Visible = false;

            txtMedCategory.Enabled = false;
        }
    }
}