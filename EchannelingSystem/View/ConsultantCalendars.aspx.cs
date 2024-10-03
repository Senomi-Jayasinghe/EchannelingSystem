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
    public partial class ConsultantCalendars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getCalendar();
        }

        protected void grdCalendar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grdCalendar.Rows[rowIndex];
            HiddenField field = (HiddenField)row.FindControl("hdnGrdCalendarId");

            if (e.CommandName == "View")
            {
                Response.Redirect("CalendarUI.aspx?appCalendarID=" + field.Value + "&mode=V");
            }
            else if (e.CommandName == "Delete")
            {
                Response.Redirect("CalendarUI.aspx?appCalendarID=" + field.Value + "&mode=D");
            }
            else
            {
                Response.Redirect("CalendarUI.aspx?appCalendarID=" + field.Value + "&mode=U");
            }
        }

        protected void getCalendar()
        {
            AppCalendarController appCalendarController = new AppCalendarController();
            AppCalendar appCalendar = new AppCalendar();

            DataTable dt = new DataTable();
            int UserID = Convert.ToInt32(Session["USER_ID"]);

            dt = appCalendarController.getCalendar(UserID);

            if (dt.Rows.Count == 0)
            {
                PnlMsg.Visible = true;
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    appCalendar.appCalendarID = Convert.ToInt32(dr["appCalendar_id"]);
                    appCalendar.date = Convert.ToDateTime(dr["date"]);
                    if (appCalendar.date < DateTime.Now)
                    {
                        appCalendar.status = "I";
                        appCalendarController.DeleteAppointment(appCalendar);
                    }
                }

                DataTable dt2 = new DataTable();
                dt2 = appCalendarController.getCalendar(UserID);
                grdCalendar.DataSource = dt2;
                grdCalendar.DataBind();
            }
        }
    }
}