using EchannelingSystem.Database;
using EchannelingSystem.Model;
using EchannelingSystem.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;

namespace EchannelingSystem.Controller
{
    public class AppCalendarController
    {
        public void SaveAppointment(AppCalendar appCalendar)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "insert into AppCalendar(branch_id, consultant_id, date, from_time, to_time, web_quota, offline_quota, balance, status, " +
                "consultation_fee, entry_user, entry_date) values " +
                "(" + appCalendar.branchID + ", " + appCalendar.consultantID + ", '" + appCalendar.date + "', '" + appCalendar.fromTime + "', '"
                + appCalendar.toTime + "', " + appCalendar.webQuota + ", " + appCalendar.offlineQuota + ", " + appCalendar.balance + ", '"
                + appCalendar.status + "', " + appCalendar.consultationFee + ", " + appCalendar.entryUser + ", '" + appCalendar.entryDate + "')";
            sQLConfig.ExecuteCUD(sql);
        }

        public void UpdateAppointment(AppCalendar appCalendar)
        {
            SQLConfig sqlConfig = new SQLConfig();
            string sql = "Update AppCalendar set branch_id = " + appCalendar.branchID + ", consultant_id = " + appCalendar.consultantID + ", date = '" + appCalendar.date + "', from_time = '"
                + appCalendar.fromTime + "', to_time = '" + appCalendar.toTime + "', web_quota = " + appCalendar.webQuota + ", offline_quota = " + appCalendar.offlineQuota
                + ", balance = " + appCalendar.balance + ", status = '" + appCalendar.status + "', consultation_fee = " + appCalendar.consultationFee +
                " where appCalendar_id = " + appCalendar.appCalendarID;
            sqlConfig.ExecuteCUD(sql);
        }

        public void DeleteAppointment(AppCalendar appCalendar)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Update AppCalendar set status = '" + appCalendar.status + "' where appCalendar_id = " + appCalendar.appCalendarID;
            sQLConfig.ExecuteCUD(sql);
        }

        public DataTable getAppointment(Consultant consultant, int Specialization, AppCalendar appCalendar)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "SELECT  a.appCalendar_id, c.consultant_id, c.consultant_fullname, c.consultant_gender, a.date, b.branch_name, " +
                "sp.specialization_description from " +
                "Consultant c inner join AppCalendar a on(c.consultant_id = a.consultant_id) " +
                "left outer join ConsultantSpecialization s on(c.consultant_id = s.consultant_id) " +
                "LEFT OUTER JOIN Specialization sp ON (s.specialization_id = sp.specialization_id) " +
                "left outer join Branch b ON a.branch_id = b.branch_id " + 
                "where (c.consultant_fullname like '%" + consultant.consultantFullname + "%' OR '' = '" + consultant.consultantFullname + "') " +
                "AND (c.consultant_gender = '" + consultant.consultantGender + "' OR '' = '" + consultant.consultantGender + "') " +
                "AND (s.specialization_id = " + Specialization + " OR 0 = " + Specialization + ") " +
                "AND (a.date = '" + appCalendar.date + "' OR cast('01/01/2000' as date) = '" + appCalendar.date + "') " +
                "AND (a.branch_id = " + appCalendar.branchID + " OR 0 = " + appCalendar.branchID + ")" +
                "AND (a.status = 'A')";

            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }

        public DataTable getCalendar(int userid)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select appCalendar_id, date, from_time, to_time, balance, status from AppCalendar where consultant_id = " + userid 
                + "order by date DESC";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }

        public AppCalendar getAppCalendarByID(int appCalendarId)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select branch_id, consultant_id, date, from_time, to_time, web_quota, offline_quota, balance, consultation_fee from AppCalendar";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            AppCalendar appCalendar = new AppCalendar();

            foreach (DataRow dr in dt.Rows)
            {
                appCalendar.branchID = Convert.ToInt32(dr["branch_id"]);
                appCalendar.consultantID = Convert.ToInt32(dr["consultant_id"]);
                appCalendar.date = Convert.ToDateTime(dr["date"]);
                appCalendar.fromTime = dr["from_time"].ToString();
                appCalendar.toTime = dr["to_time"].ToString();
                appCalendar.webQuota = Convert.ToInt32(dr["web_quota"]);
                appCalendar.offlineQuota = Convert.ToInt32(dr["offline_quota"]);
                appCalendar.balance = Convert.ToInt32(dr["balance"]);
                appCalendar.consultationFee = Convert.ToDecimal(dr["consultation_fee"]);

            }

            return appCalendar;
        }

        public DataTable getPatients(int appCalendarId)
        {
            SQLConfig sqlConfig = new SQLConfig();
            string sql = "SELECT a.appointment_id, a.appointment_seq, p.patient_id, p.patient_fullname, p.patient_gender, p.patient_mobileno, " +
                "DATEDIFF(YEAR, p.patient_dob, GETDATE()) - " +
                "CASE " +
                "WHEN MONTH(p.patient_dob) > MONTH(GETDATE()) " +
                "OR (MONTH(p.patient_dob) = MONTH(GETDATE()) AND DAY(p.patient_dob) > DAY(GETDATE())) THEN 1 ELSE 0 END AS patient_age " +
                "FROM Appointment a JOIN Patient p ON a.patient_id = p.patient_id WHERE a.appCalendar_id = " + appCalendarId;
            DataTable dt = sqlConfig.ExecuteSelect(sql);
            return dt;
        }
    }
}