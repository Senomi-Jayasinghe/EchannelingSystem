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
    public partial class PatientConsultantSearchUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getSpecializationData(); //Get specializations to dropdown lisrt from DB
                getBranchData();//Get branches to dropdown lisrt from DB
            }
        }

        public void getSpecializationData()
        {   //Getting Specializations from DB
            try
            {
                SpecializationController specializationController = new SpecializationController();
                DataTable dt = new DataTable();
                dt = specializationController.getSpecialization();
                //Binding data to Drop down
                ddlSpecialization.DataSource = dt;
                ddlSpecialization.DataTextField = "specialization_description";
                ddlSpecialization.DataValueField = "specialization_id";
                ddlSpecialization.DataBind();

                ddlSpecialization.Items.Insert(0, new ListItem("", "0"));
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void getBranchData()
        {   //Getting Branches from DB
            BranchController branchController = new BranchController();
            DataTable dt = new DataTable();
            dt = branchController.GetBranch();
            //Binding data to Drop down
            ddlBranch.DataSource = dt;
            ddlBranch.DataTextField = "branch_name";
            ddlBranch.DataValueField = "branch_id";
            ddlBranch.DataBind();

            ddlBranch.Items.Insert(0, new ListItem("", "0"));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if(ddlDate.Text.Trim() != string.Empty)
                {   //Checking if date is smaller than current date
                    if (Convert.ToDateTime(ddlDate.Text) < DateTime.Now)
                    {   //if date is smaller than current date, show message
                        throw new ArgumentException("Select a valid date");
                    }
                }       
                AppCalendarController appCalendarController = new AppCalendarController();
                AppCalendar appCalendar = new AppCalendar();
                Consultant consultant = new Consultant();

                consultant.consultantFullname = txtName.Text;
                int Specialization = Convert.ToInt32(ddlSpecialization.SelectedValue);

                if (ddlDate.Text.Trim() == string.Empty)
                {   //set default date for query if patient does not enter a date
                    appCalendar.date = Convert.ToDateTime("01/01/2000");
                }
                else
                {
                    appCalendar.date = Convert.ToDateTime(ddlDate.Text);
                }
                appCalendar.branchID = Convert.ToInt32(ddlBranch.SelectedValue);
                consultant.consultantGender = ddlGender.SelectedValue;

                DataTable dt = new DataTable();

                dt = appCalendarController.getAppointment(consultant, Specialization, appCalendar);

                if (dt.Rows.Count == 0)
                {   //if query doesn't return any matching data
                    PnlMsg.Text = "No Appointments Available";
                }
                else
                {   //else show appointments
                    setResult(dt);
                }
            }
            catch (Exception ex)
            {
                PnlMsg.Text = ex.Message;
            }
        }
        protected void setResult(DataTable dt)
        {   //setting appointments in the form of cards
            string htmlCode = "<div class=\"row row-cols-1 row-cols-md-3 g-4\">";
            foreach (DataRow dr in dt.Rows)
            {
                string formattedDate = Convert.ToDateTime(dr["date"]).ToString("MM/dd/yyyy");
                htmlCode = htmlCode + @"<div class='col'>
                        <div class='card' style='width: 250px;'>
                            <img src='' class='card-img-top'>
                            <div class='card-body'>
                                <h5 class='card-title'><center>" + dr["consultant_fullname"] + @"</center></h5>
                                <p class='card-text'>
                                <table>
                                   <tr><td>Gender: " + dr["consultant_gender"] + @"</td></tr>
                                   <tr><td>Branch: " + dr["branch_name"] + @"</td></tr>
                                   <tr><td>Date: " + formattedDate + @"</td></tr>
                                   <tr><td>Specialization: " + dr["specialization_description"] + @"</td></tr>
                                </table>
                                </p>
                                <center>
                                    <a href='AppointmentUI.aspx?id=" + dr["appCalendar_id"] + @"' target='_self' class='btn btn-primary btn-block'>Book Appointment</a>
                                </center>
                            </div>
                        </div>
                        </div>";
            }
            lblSearchResult.Text = htmlCode + "</div>";
        }
    }
}