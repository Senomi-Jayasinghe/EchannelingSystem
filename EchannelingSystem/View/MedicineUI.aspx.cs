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
    public partial class MedicineUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getMedicineCategoryData();
                getDataFromDatabase();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MedicineController medicineController = new MedicineController();
                Medicine medicine = new Medicine();

                medicine.medicineDescription = txtMedicineDesc.Text;
                medicine.medicineScientificName = txtScientificName.Text;
                medicine.medicineCategoryID =Convert.ToInt32(ddlMedCategory.SelectedValue);

                if (btnSave.Text == "Save")
                {
                    medicineController.SaveMedicine(medicine);
                    lblPnlMsg.Text = "Save Success";
                }
                else if (btnSave.Text == "Update")
                {
                    medicine.medicineID = Convert.ToInt32(hdnMedicineId.Value);
                    medicineController.UpdateMedicine(medicine);
                    lblPnlMsg.Text = "Update Success";
                }
                else if (btnSave.Text == "Delete")
                {
                    medicine.medicineID = Convert.ToInt32(hdnMedicineId.Value);
                    medicineController.DeleteMedicine(medicine);
                    lblPnlMsg.Text = "Delete Success";
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
                MedicineController medicineController = new MedicineController();
                DataTable dt = new DataTable();
                dt = medicineController.getMedicine();

                grdMedicine.DataSource = dt;
                grdMedicine.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtMedicineDesc.Text = string.Empty;
            txtScientificName.Text = string.Empty;
            ddlMedCategory.SelectedIndex = 0;
        }

        protected void grdMedicine_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            HiddenField field = (HiddenField)grdMedicine.Rows[e.NewSelectedIndex].FindControl("hdnGrdMedicineId");
            MedicineController medicineController = new MedicineController();
            Medicine medicine = medicineController.getMedicineByID(Convert.ToInt32(field.Value));
            hdnMedicineId.Value = field.Value;
            ddlMedCategory.SelectedValue = medicine.medicineCategoryID.ToString();
            txtMedicineDesc.Text = medicine.medicineDescription;
            txtScientificName.Text = medicine.medicineScientificName;

            btnSave.Text = "Update";
            btnReset.Visible = false;
        }

        protected void grdMedicine_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HiddenField field = (HiddenField)grdMedicine.Rows[e.RowIndex].FindControl("hdnGrdMedicineId");
            MedicineController medicineController = new MedicineController();
            Medicine medicine = medicineController.getMedicineByID(Convert.ToInt32(field.Value));
            hdnMedicineId.Value = field.Value;
            ddlMedCategory.SelectedIndex = medicine.medicineCategoryID;
            txtMedicineDesc.Text = medicine.medicineDescription;
            txtScientificName.Text = medicine.medicineScientificName;

            btnSave.Text = "Delete";
            btnReset.Visible = false;

            ddlMedCategory.Enabled = false;
            txtMedicineDesc.Enabled = false;
            txtScientificName.Enabled = false;
        }

        protected void getMedicineCategoryData()
        {
            MedicineCategoryController medicineCategoryController = new MedicineCategoryController();
            DataTable dt = new DataTable();
            dt = medicineCategoryController.getMedicineCategory();

            ddlMedCategory.DataSource = dt;
            ddlMedCategory.DataTextField = "medicine_category_description";
            ddlMedCategory.DataValueField = "medicine_category_id";
            ddlMedCategory.DataBind();

            ddlMedCategory.Items.Insert(0, new ListItem("Select Medicine Category", "0"));
        }
    }
}