using EchannelingSystem.Controller;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchannelingSystem.View
{
    public partial class LabReportsUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getDataFromDatabase();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                LabReportsController labReportsController = new LabReportsController();
                LabReports labReports = new LabReports();

                labReports.reportDescription = txtDescription.Text;

                if (btnSave.Text == "Save")
                {
                    labReportsController.SaveLabReports(labReports);
                    lblPnlMsg.Text = "Save Success";
                }
                else if (btnSave.Text == "Update")
                {
                    labReports.reportID = Convert.ToInt32(hdnLabReportsId.Value);
                    labReportsController.UpdateLabReports(labReports);
                    lblPnlMsg.Text = "Update Succees";
                }
                else if (btnSave.Text == "Delete")
                {
                    labReports.reportID = Convert.ToInt32(hdnLabReportsId.Value);
                    labReportsController.DeleteLabReports(labReports);
                    lblPnlMsg.Text = "Delete Succees";
                }

                getDataFromDatabase();

                pnlMsg.Visible = true;
                pnlMsg.CssClass = "alert alert-success";
            }
            catch (Exception ex)
            {
                pnlMsg.Visible = true;
                lblPnlMsg.Text = "Save Error!" + ex.Message;
                pnlMsg.CssClass = "aler alert-danger";
            }
        }

        public void getDataFromDatabase()
        {
            try
            {
                LabReportsController labReportsController = new LabReportsController();
                DataTable dt = new DataTable();
                dt = labReportsController.getLabReports();

                grdLabReports.DataSource = dt;
                grdLabReports.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtDescription.Text = string.Empty;
        }

        protected void grdLabReports_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            HiddenField field = (HiddenField)grdLabReports.Rows[e.NewSelectedIndex].FindControl("hdnGrdLabReportsId");
            LabReportsController labReportsController = new LabReportsController();
            LabReports labReports = labReportsController.getLabReportsByID(Convert.ToInt32(field.Value));
            hdnLabReportsId.Value = field.Value;
            txtDescription.Text = labReports.reportDescription;

            btnSave.Text = "Update";
            btnReset.Visible = false;

        }

        protected void grdLabReports_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HiddenField field = (HiddenField)grdLabReports.Rows[e.RowIndex].FindControl("hdnGrdLabReportsId");
            LabReportsController labReportsController = new LabReportsController();
            LabReports labReports = labReportsController.getLabReportsByID(Convert.ToInt32(field.Value));
            hdnLabReportsId.Value = field.Value;
            txtDescription.Text = labReports.reportDescription;

            btnSave.Text = "Delete";
            btnReset.Visible = false;

            txtDescription.Enabled = false;
        }
    }
}