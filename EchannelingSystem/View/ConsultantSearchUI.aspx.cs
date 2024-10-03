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
    public partial class ConsultantSearchUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try //Search
            {
                ConsultantController consultantController = new ConsultantController();
                Consultant consultant = new Consultant();
                consultant.consultantInitial = txtInitial.Text;
                consultant.consultantLname = txtLastName.Text;
                consultant.consultantContact1 = txtContactNo.Text;
                consultant.consultantEmail = txtEmail.Text;
                if (txtRegisterID.Text.Trim() != string.Empty)
                {
                    consultant.consultantRegisterID = Convert.ToInt32(txtRegisterID.Text);

                }
                else
                {
                    consultant.consultantRegisterID = 0;

                }
                DataTable dt = new DataTable();

                dt = consultantController.getConsultant(consultant);

                grdConsultant.DataSource = dt;
                grdConsultant.DataBind(); //BIND SEARCH RESULTS TO GRID
            }

            catch (Exception)
            {
                throw;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {//RESET
            txtInitial.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtRegisterID.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        protected void grdConsultant_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {   //UPDATE CONSULTANT INFORMATION
            HiddenField field = (HiddenField)grdConsultant.Rows[e.NewSelectedIndex].FindControl("hdnGrdConsultantId");
            Consultant consultant = new Consultant();
            hdnConsultantId.Value = field.Value;
            consultant.consultantID = Convert.ToInt32(field.Value);
            Response.Redirect("ConsultantUI.aspx?ConsultantID=" + consultant.consultantID + "&mode=U");
        }

        protected void grdConsultant_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {   //DELETE 
            HiddenField field = (HiddenField)grdConsultant.Rows[e.RowIndex].FindControl("hdnGrdConsultantId");
            Consultant consultant = new Consultant();
            hdnConsultantId.Value = field.Value;
            consultant.consultantID = Convert.ToInt32(field.Value);
            Response.Redirect("ConsultantUI.aspx?ConsultantID=" + consultant.consultantID + "&mode=D");
        }
    }
}