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
    public partial class SpecializationUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getDataFromDatabase();//GET DATA FROM DB TO GRID
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SpecializationController specializationController = new SpecializationController();
                Specialization specialization = new Specialization();

                specialization.specializationDescription = txtSpecialization.Text;

                if (btnSave.Text == "Save")
                {//SAVE
                    specializationController.SaveSpecialization(specialization);
                    lblPnlMsg.Text = "Save Success";
                }
                else if (btnSave.Text == "Update")
                {//GET SELECTED ID AND UPDATE
                    specialization.specializationID = Convert.ToInt32(hdnSpecializationId.Value);
                    specializationController.UpdateSpecialization(specialization);
                    lblPnlMsg.Text = "Update Success";
                }
                else if (btnSave.Text == "Delete")
                {//GET SELECTED ID AND DELETE
                    specialization.specializationID = Convert.ToInt32(hdnSpecializationId.Value);
                    specializationController.DeleteSpecialization(specialization);
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
                SpecializationController specializationController = new SpecializationController();
                DataTable dt = new DataTable();
                dt = specializationController.getSpecialization();
                //GET DATA FROM DB AND BIND TO GRID
                grdSpecialization.DataSource = dt;
                grdSpecialization.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtSpecialization.Text = string.Empty; //RESET FIELDS TO EMPTY
        }

        protected void grdSpecialization_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {//UPDATE
            HiddenField field = (HiddenField)grdSpecialization.Rows[e.NewSelectedIndex].FindControl("hdnGrdSpecializationId");
            SpecializationController specializationController = new SpecializationController();
            Specialization specialization = specializationController.getSpecializationByID(Convert.ToInt32(field.Value));
            hdnSpecializationId.Value = field.Value;
            txtSpecialization.Text = specialization.specializationDescription;//FILL FORM WITH DATA

            btnSave.Text = "Update";//CHANGE SAVE TO UPDATE BUTTON
            btnReset.Visible = false;
        }

        protected void grdSpecialization_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {//DELETE
            HiddenField field = (HiddenField)grdSpecialization.Rows[e.RowIndex].FindControl("hdnGrdSpecializationId");
            SpecializationController specializationController = new SpecializationController();
            Specialization specialization = specializationController.getSpecializationByID(Convert.ToInt32(field.Value));
            hdnSpecializationId.Value = field.Value;
            txtSpecialization.Text = specialization.specializationDescription;//FILL FORM WITH DATA

            btnSave.Text = "Delete";//CHANGE SAVE TO DELETE BUTTON
            btnReset.Visible = false;

            txtSpecialization.Enabled = false;//DISABLE FIELDS
        }
    }
}