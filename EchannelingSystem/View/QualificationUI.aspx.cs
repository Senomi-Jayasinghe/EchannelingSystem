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
    public partial class QualificationUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getDataFromDatabase(); //GET DATA FROM DB TO GRID
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                QualificationController qualificationController = new QualificationController();
                Qualification qualification = new Qualification();

                qualification.qualificationDescription = txtQualification.Text;

                if (btnSave.Text == "Save")
                {//SAVE
                    qualificationController.SaveQualification(qualification);
                    lblPnlMsg.Text = "Save Success";
                }
                else if (btnSave.Text == "Update")
                {//GET SELECTED ID AND UPDATE
                    qualification.qualificationID = Convert.ToInt32(hdnQualificationId.Value);
                    qualificationController.UpdateQualification(qualification);
                    lblPnlMsg.Text = "Update Success";
                }
                else if (btnSave.Text == "Delete")
                {//GET SELECTED ID AND DELETE
                    qualification.qualificationID = Convert.ToInt32(hdnQualificationId.Value);
                    qualificationController.DeleteQualification(qualification);
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
                QualificationController qualificationController = new QualificationController();
                DataTable dt = new DataTable();
                dt = qualificationController.getQualification();
                //GET DATA FROM DB AND BIND TO GRID
                grdQualification.DataSource = dt;
                grdQualification.DataBind();

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtQualification.Text = string.Empty;//RESET FIELDS TO EMPTY
        }

        protected void grdQualification_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {//UPDATE
            HiddenField field = (HiddenField)grdQualification.Rows[e.NewSelectedIndex].FindControl("hdnGrdQualificationId");
            QualificationController qualificationController = new QualificationController();
            Qualification qualification = qualificationController.getQualificationByID(Convert.ToInt32(field.Value));
            hdnQualificationId.Value = field.Value;
            txtQualification.Text = qualification.qualificationDescription;//FILL FORM WITH DATA

            btnSave.Text = "Update";//CHANGE SAVE TO UPDATE BUTTON
            btnReset.Visible = false;
        }

        protected void grdQualification_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {//DELETE
            HiddenField field = (HiddenField)grdQualification.Rows[e.RowIndex].FindControl("hdnGrdQualificationId");
            QualificationController qualificationController = new QualificationController();
            Qualification qualification = qualificationController.getQualificationByID(Convert.ToInt32(field.Value));
            hdnQualificationId.Value = field.Value;
            txtQualification.Text = qualification.qualificationDescription;//FILL FORM WITH DATA

            btnSave.Text = "Delete";//CHANGE SAVE TO DELETE BUTTON
            btnReset.Visible = false;

            txtQualification.Enabled = false;//DISABLE FIELDS
        }
    }
}