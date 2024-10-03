using EchannelingSystem.Database;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EchannelingSystem.Controller
{
    public class PaymentController
    {
        public DataTable getPaymentInfo(int appseq, int appId)
        {
            SQLConfig sqlConfig = new SQLConfig();
            string sql = "SELECT a.appointment_id, p.patient_initial, p.patient_lname, p.patient_email, p.patient_mobileno, p.patient_address, " +
                "p.patient_branch_id, d.district_description, ac.consultation_fee FROM Appointment a " +
                "JOIN Patient p ON a.patient_id = p.patient_id JOIN AppCalendar ac ON a.appCalendar_id = ac.appCalendar_id " +
                "JOIN District d ON p.patient_district_id = d.district_id " +
                "WHERE a.appointment_seq = " + appseq + " AND a.appCalendar_id =" + appId;
            DataTable dt = sqlConfig.ExecuteSelect(sql);
            return dt;
        }

        public void enterPaymentdetails(PaymentDetails paymentDetails, int appointmentid)
        {
            SQLConfig sqlConfig = new SQLConfig();
            string sql = "INSERT into PaymentDetails (payment_branch_id, payment_category_id, payment_amount, payment_type_id, payment_status, " +
                "entry_user, entry_date) values (" + paymentDetails.paymentBranchID + ", " + paymentDetails.paymentCategoryID + ", "
                + paymentDetails.paymentAmount + ", " + paymentDetails.paymentTypeID + ", '" + paymentDetails.paymentStatus + "', "
                + paymentDetails.entryUser + ", '" + paymentDetails.entryDate + "');" +
                " select CAST(scope_identity() as int)"; 
            int maxID = Convert.ToInt32(sqlConfig.InsertDataWithReturnId(sql));

            string sqlu = "Update Appointment set payment_id = " + maxID + "where appointment_id = " + appointmentid;
            sqlConfig.ExecuteCUD(sqlu);
        }
    }
}