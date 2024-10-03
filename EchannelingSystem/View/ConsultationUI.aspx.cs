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
    public partial class ConsultationUI : System.Web.UI.Page
    {
        List<Symptom> symptomsList = new List<Symptom>();
        List<Disease> diseaseList = new List<Disease>();
        List<Medicine> medicineList = new List<Medicine>();
        List<LabReports> labreportsList = new List<LabReports>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getSymptomData();
                getDiseaseData();
                getMedicineData();
                getReportData();
            }
            else
            {
                if (ViewState["SymptomData"] != null)
                {
                    symptomsList = (List<Symptom>)ViewState["SymptomData"];
                }
                if (ViewState["DiseaseData"] != null)
                {
                    diseaseList = (List<Disease>)ViewState["DiseaseData"];
                }
                if (ViewState["MedicineData"] != null)
                {
                    medicineList = (List<Medicine>)ViewState["MedicineData"];
                }
                if (ViewState["LabReportsData"] != null)
                {
                    labreportsList = (List<LabReports>)ViewState["LabReportsData"];
                }
            }
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

        protected void getDiseaseData()
        {
            DiseaseController diseaseController = new DiseaseController();
            DataTable dt = new DataTable();
            dt = diseaseController.getDisease();

            ddlDisease.DataSource = dt;
            ddlDisease.DataTextField = "disease_name";
            ddlDisease.DataValueField = "disease_id";
            ddlDisease.DataBind();

            ddlDisease.Items.Insert(0, new ListItem("Select Disease", "0"));
        }
        protected void ddlDisease_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDisease.SelectedValue != "0")
            {
                Disease disease = new Disease();
                disease.diseaseID = Convert.ToInt32(ddlDisease.SelectedValue);
                disease.diseaseName = ddlDisease.SelectedItem.Text;
                diseaseList.Add(disease);
                ViewState["DiseaseData"] = diseaseList;

                grdDisease.DataSource = diseaseList;
                grdDisease.DataBind();
            }
        }

        protected void grdDisease_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                List<Disease> diseaseData = (List<Disease>)ViewState["DiseaseData"];
                diseaseData.RemoveAt(rowIndex);
                grdDisease.DataSource = diseaseData;
                grdDisease.DataBind();
            }
        }

        protected void getMedicineData()
        {
            MedicineController medicineController = new MedicineController();
            DataTable dt = new DataTable();
            dt = medicineController.getMedicineInfo();

            ddlMedicine.DataSource = dt;
            ddlMedicine.DataTextField = "medicine_description";
            ddlMedicine.DataValueField = "medicine_id";
            ddlMedicine.DataBind();

            ddlMedicine.Items.Insert(0, new ListItem("Select Medicine", "0"));
        }

        protected void ddlMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMedicine.SelectedValue != "0")
            {
                Medicine medicine = new Medicine();
                medicine.medicineID = Convert.ToInt32(ddlMedicine.SelectedValue);
                medicine.medicineDescription = ddlMedicine.SelectedItem.Text;
                medicineList.Add(medicine);
                ViewState["MedicineData"] = medicineList;

                grdMedicine.DataSource = medicineList;
                grdMedicine.DataBind();
            }
        }

        protected void grdMedicine_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                List<Medicine> medicineData = (List<Medicine>)ViewState["MedicineData"];
                medicineData.RemoveAt(rowIndex);
                grdMedicine.DataSource = medicineData;
                grdMedicine.DataBind();
            }
        }

        protected void getReportData()
        {
            LabReportsController labReportsController = new LabReportsController();
            DataTable dt = new DataTable();
            dt = labReportsController.getLabReports();

            ddlReport.DataSource = dt;
            ddlReport.DataTextField = "report_description";
            ddlReport.DataValueField = "report_id";
            ddlReport.DataBind();

            ddlReport.Items.Insert(0, new ListItem("Select Report", "0"));
        }

        protected void ddlReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReport.SelectedValue != "0")
            {
                LabReports labReports = new LabReports();
                labReports.reportID = Convert.ToInt32(ddlReport.SelectedValue);
                labReports.reportDescription = ddlReport.SelectedItem.Text;
                labreportsList.Add(labReports);
                ViewState["LabReportsData"] = labreportsList;

                grdReport.DataSource = labreportsList;
                grdReport.DataBind();
            }
        }

        protected void grdReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                List<LabReports> labreportsData = (List<LabReports>)ViewState["LabReportsData"];
                labreportsData.RemoveAt(rowIndex);
                grdReport.DataSource = labreportsData;
                grdReport.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Consultation consultation = new Consultation();
            consultation.nextVisit = Convert.ToDateTime(ddlDateAvailable.Text);

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlDateAvailable.Text = string.Empty;
            ddlSymptoms.SelectedIndex = 0;
            ddlDisease.SelectedIndex = 0;
            ddlMedicine.SelectedIndex = 0;
            ddlReport.SelectedIndex = 0;
        }
    }
}