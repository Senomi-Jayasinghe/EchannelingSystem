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
    public partial class SymptomUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getDataFromDatabase();//GET DATA FROM DB TO GRID
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SymptomController symptomController = new SymptomController();
                Symptom symptom = new Symptom();

                symptom.symptomName = txtSymptomName.Text;
                symptom.symptomDescription = txtDescription.InnerText;

                if (btnSave.Text == "Save")
                {//SAVE
                    symptomController.SaveSymptom(symptom);
                    lblPnlMsg.Text = "Save Success";
                }
                else if (btnSave.Text == "Update")
                {//GET SELECTED ID AND UPDATE
                    symptom.symptomID = Convert.ToInt32(hdnSymptomId.Value);
                    symptomController.UpdateSymptom(symptom);
                    lblPnlMsg.Text = "Update Success";
                }
                else if (btnSave.Text == "Delete")
                {//GET SELECTED ID AND DELETE
                    symptom.symptomID = Convert.ToInt32(hdnSymptomId.Value);
                    symptomController.DeleteSymptom(symptom);
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
                SymptomController symptomController = new SymptomController();
                DataTable dt = new DataTable();
                dt = symptomController.getSymptom();
                //GET DATA FROM DB AND BIND TO GRID
                grdSymptom.DataSource = dt;
                grdSymptom.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {//RESET FIELDS TO EMPTY
            txtSymptomName.Text = string.Empty;
            txtDescription.InnerText = string.Empty;
        }

        protected void grdSymptom_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {//UPDATE
            HiddenField field = (HiddenField)grdSymptom.Rows[e.NewSelectedIndex].FindControl("hdnGrdSymptomId");
            SymptomController symptomController = new SymptomController();
            Symptom symptom = symptomController.getSymptomByID(Convert.ToInt32(field.Value));
            hdnSymptomId.Value = field.Value;
            txtSymptomName.Text = symptom.symptomName;//FILL FORM WITH DATA
            txtDescription.InnerText = symptom.symptomDescription;
            //CHANGE SAVE TO UPDATE BUTTON
            btnSave.Text = "Update";
            btnReset.Visible = false;
        }

        protected void grdSymptom_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {//DELETE
            HiddenField field = (HiddenField)grdSymptom.Rows[e.RowIndex].FindControl("hdnGrdSymptomId");
            SymptomController symptomController = new SymptomController();
            Symptom symptom = symptomController.getSymptomByID(Convert.ToInt32(field.Value));
            hdnSymptomId.Value = field.Value;
            txtSymptomName.Text = symptom.symptomName;//FILL FORM WITH DATA
            txtDescription.InnerText = symptom.symptomDescription;

            btnSave.Text = "Delete";//CHANGE SAVE TO DELETE BUTTON
            btnReset.Visible = false;

            txtSymptomName.Enabled = false;//DISABLE FIELDS
            txtDescription.Disabled = true;
        }
    }
}