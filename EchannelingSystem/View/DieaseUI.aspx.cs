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
    public partial class DieaseUI : System.Web.UI.Page
    {
        List<Symptom> symptomsList = new List<Symptom>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ROLE"].ToString() != "3")
            {
                Response.Redirect("LoginUI.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    getSymptomData();
                    getDataFromDatabase();
                }
                else
                {
                    if (ViewState["SymptomData"] != null)
                    {
                        symptomsList = (List<Symptom>)ViewState["SymptomData"];
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DiseaseController diseaseController = new DiseaseController();
                Disease disease = new Disease();

                disease.diseaseName = txtDiseaseName.Text;
                disease.diseaseDescription = txtDescription.InnerText;

                if (btnSave.Text == "Save")
                {
                    diseaseController.SaveDisease(disease,symptomsList);
                    lblPnlMsg.Text = "Save Success";
                }
                else if (btnSave.Text == "Update")
                {
                    disease.diseaseID = Convert.ToInt32(hdnDiseaseId.Value);
                    diseaseController.UpdateDisease(disease,symptomsList);
                    lblPnlMsg.Text = "Update Success";
                }
                else if (btnSave.Text == "Delete")
                {
                    disease.diseaseID = Convert.ToInt32(hdnDiseaseId.Value);
                    diseaseController.DeleteDisease(disease);
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
                DiseaseController diseaseController = new DiseaseController();
                DataTable dt = new DataTable();
                dt = diseaseController.getDisease();

                grdDisease.DataSource = dt;
                grdDisease.DataBind();
            }

            catch (Exception)
            {
                throw;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtDiseaseName.Text = string.Empty;
            txtDescription.InnerText = string.Empty;
            ddlSymptoms.SelectedIndex = 0;
        }

        protected void grdDisease_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            HiddenField field = (HiddenField)grdDisease.Rows[e.NewSelectedIndex].FindControl("hdnGrdDiseaseId");
            DiseaseController diseaseController = new DiseaseController();
            (Disease disease, List<Symptom> symptomList) = diseaseController.getDiseaseByID(Convert.ToInt32(field.Value));
            hdnDiseaseId.Value = field.Value;
            txtDiseaseName.Text = disease.diseaseName;
            txtDescription.InnerText = disease.diseaseDescription;

            ViewState["SymptomData"] = symptomList;
            grdSymptoms.DataSource = symptomList;
            grdSymptoms.DataBind();

            btnSave.Text = "Update";
            btnReset.Visible = false;
        }

        protected void grdDisease_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HiddenField field = (HiddenField)grdDisease.Rows[e.RowIndex].FindControl("hdnGrdDiseaseId");
            DiseaseController diseaseController = new DiseaseController();
            (Disease disease, List<Symptom> symptomList) = diseaseController.getDiseaseByID(Convert.ToInt32(field.Value));
            hdnDiseaseId.Value = field.Value;
            txtDiseaseName.Text = disease.diseaseName;
            txtDescription.InnerText = disease.diseaseDescription;

            ViewState["SymptomData"] = symptomList;
            grdSymptoms.DataSource = symptomList;
            grdSymptoms.DataBind();

            btnSave.Text = "Delete";
            btnReset.Visible = false;

            txtDiseaseName.Enabled = false;
            txtDescription.Disabled = true;
        }

        protected void ddlSymptoms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSymptoms.SelectedValue != "0")
            {
                Symptom symptom = new Symptom();
                symptom.symptomID = Convert.ToInt32(ddlSymptoms.SelectedValue);
                symptom.symptomName = ddlSymptoms.SelectedItem.Text;
                symptomsList.Add(symptom);
                ViewState["SymptomData"] = symptomsList;

                grdSymptoms.DataSource = symptomsList;
                grdSymptoms.DataBind();
            }
        }

        protected void grdSymptoms_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                List<Symptom> symptomData = (List<Symptom>)ViewState["SymptomData"];
                symptomData.RemoveAt(rowIndex);
                grdSymptoms.DataSource = symptomData;
                grdSymptoms.DataBind();
            }
        }

        protected void getSymptomData()
        {
            SymptomController symptomController = new SymptomController();
            DataTable dt = new DataTable();
            dt = symptomController.getSymptom();

            ddlSymptoms.DataSource = dt;
            ddlSymptoms.DataTextField = "symptom_name";
            ddlSymptoms.DataValueField = "symptom_id";
            ddlSymptoms.DataBind();

            ddlSymptoms.Items.Insert(0, new ListItem("Select Symptom", "0"));
        }
    }
}