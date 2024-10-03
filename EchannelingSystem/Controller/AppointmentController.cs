using EchannelingSystem.Database;
using EchannelingSystem.Model;
using EchannelingSystem.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace EchannelingSystem.Controller
{
    public class AppointmentController
    {
        public DataTable getAppointmentData(int appID)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select c.consultant_fullname, c.consultant_id, a.date, a.from_time, a.to_time, a.balance, a.consultation_fee, b.branch_name from " +
                "AppCalendar a " +
                "INNER JOIN Consultant c ON a.consultant_id = c.consultant_id INNER JOIN Branch b ON a.branch_id = b.branch_id " +
                "where a.appCalendar_id = " + appID;
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }

        public void bookAppointment(Appointment appointment)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Insert into Appointment(patient_id, consultant_id, appCalendar_id, appointment_seq, appointment_status, payment_id, entry_user, " +
                "entry_date) VALUES (" + appointment.patientID + ", " + appointment.consultantID + ", " + appointment.appCalendarID + ", "
                + appointment.appointmentSeq + ", '" + appointment.appointmentStatus + "', " + appointment.paymentID + ", " + appointment.entryUser + ", '"
                + appointment.entryDate + "')";
            sQLConfig.ExecuteCUD(sql);

            string sqlUpdatebal = "Update AppCalendar set balance = balance + 1 where appCalendar_id = " + appointment.appCalendarID;
            sQLConfig.ExecuteCUD(sqlUpdatebal);

        }

        public int appointmentSequence(int appId)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "SELECT MAX(appointment_seq) AS max_seq FROM Appointment WHERE appCalendar_id = " + appId;
            sQLConfig.ExecuteSelect(sql);
            DataTable dt = sQLConfig.ExecuteSelect(sql);

            int maxSeq = 0;

            if (dt.Rows.Count > 0 && dt.Rows[0]["max_seq"] != DBNull.Value)
            {
                maxSeq = Convert.ToInt32(dt.Rows[0]["max_seq"]);
            }

            return maxSeq + 1;
        }
    }
}