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
    public partial class BranchUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getDataFromDatabase();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BranchController branchController = new BranchController();
                Branch branch = new Branch();

                branch.branchName = txtBranchName.Text;
                branch.branchAddress = txtBranchAddress.InnerText;
                branch.branchEmail = txtBranchEmail.Text;
                branch.branchContact = txtBranchContact.Text;
                branch.branchContactPerson = txtContactPerson.Text;

                if (btnSave.Text == "Save")
                {
                    branchController.SaveBranch(branch);
                    lblPnlMsg.Text = "Save Success";
                }
                else if (btnSave.Text == "Update")
                {
                    branch.branchID = Convert.ToInt32(hdnBranchId.Value);
                    branchController.UpdateBranch(branch);
                    lblPnlMsg.Text = "Update Success";
                }
                else if (btnSave.Text == "Delete")
                {
                    branch.branchID = Convert.ToInt32(hdnBranchId.Value);
                    branchController.DeleteBranch(branch);
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


        public void getDataFromDatabase()
        {
            try
            {
                BranchController branchController = new BranchController();
                DataTable dt = new DataTable();
                dt = branchController.getBranch();

                grdBranch.DataSource = dt;
                grdBranch.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtBranchName.Text = string.Empty;
            txtBranchAddress.InnerText = string.Empty;
            txtBranchEmail.Text = string.Empty;
            txtBranchContact.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
        }

        protected void grdBranch_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            HiddenField field = (HiddenField)grdBranch.Rows[e.NewSelectedIndex].FindControl("hdnGrdBranchId");
            BranchController branchController = new BranchController();
            Branch branch = branchController.getBranchByID(Convert.ToInt32(field.Value));
            hdnBranchId.Value = field.Value;
            txtBranchName.Text = branch.branchName;
            txtBranchAddress.InnerText = branch.branchAddress;
            txtBranchEmail.Text = branch.branchEmail;
            txtBranchContact.Text = branch.branchContact;
            txtContactPerson.Text = branch.branchContactPerson;

            btnSave.Text = "Update";
            btnReset.Visible = false;
        }

        protected void grdBranch_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HiddenField field = (HiddenField)grdBranch.Rows[e.RowIndex].FindControl("hdnGrdBranchId");
            BranchController branchController = new BranchController();
            Branch branch = branchController.getBranchByID(Convert.ToInt32(field.Value));
            hdnBranchId.Value = field.Value;
            txtBranchName.Text = branch.branchName;
            txtBranchAddress.InnerText = branch.branchAddress;
            txtBranchEmail.Text = branch.branchEmail;
            txtBranchContact.Text = branch.branchContact;
            txtContactPerson.Text = branch.branchContactPerson;
            btnSave.Text = "Delete";
            btnReset.Visible = false;

            txtBranchName.Enabled = false;
            txtBranchAddress.Disabled = true;
            txtBranchEmail.Enabled = false;
            txtBranchContact.Enabled = false;
            txtContactPerson.Enabled = false;
        }          
    }
}