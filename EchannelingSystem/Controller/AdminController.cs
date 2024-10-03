using EchannelingSystem.Database;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EchannelingSystem.Controller
{
    public class AdminController
    {
        public void SaveAdmin(Admin admin, UserLogin userLogin)
        {   //INSERT
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "insert into Admin(admin_title_id, admin_initial, admin_lname, admin_fullname, admin_dob, admin_nic, admin_passport, " +
                "admin_email, admin_mobileno, admin_telephoneno, entry_user, entry_date) " +
                "values (" + admin.adminTitleID + ",'" + admin.adminInitial + "','" + admin.adminLname +
                "','" + admin.adminFullname + "','" + admin.adminDOB + "','" + admin.adminNIC + "','" + admin.adminPassport + "','" + admin.adminEmail +
                "','" + admin.adminMobileNo + "','" + admin.adminTelephoneNo + "', " + admin.entryUser + ", '" + admin.entryDate + "');" +
                "select CAST(scope_identity() as int)";

            int maxID = Convert.ToInt32(sQLConfig.InsertDataWithReturnId(sql)); ;
            //INSERT NEW CREDENTIALS
            string sqlLogin = "Insert into UserLogin(user_email, user_password, user_reference_id, user_role) values ('" + userLogin.userEmail + "','"
                + userLogin.userPassword + "'," + maxID + "," + 1 + ")";
            sQLConfig.ExecuteCUD(sqlLogin);
        }

        public void UpdateAdmin(Admin admin)
        {   //UPDATE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Update Admin set admin_title_id = " + admin.adminTitleID + ", admin_initial = '" + admin.adminInitial
                + "', admin_lname = '" + admin.adminLname + "', admin_fullname = '" + admin.adminFullname + "', admin_dob = '" + admin.adminDOB
                + "', admin_nic = '" + admin.adminNIC + "', admin_passport = '" + admin.adminPassport + "', admin_email = '" + admin.adminEmail
                + "', admin_mobileno = '" + admin.adminMobileNo + "', admin_telephoneno = '" + admin.adminTelephoneNo + "' where admin_id =" + admin.adminID;
            sQLConfig.ExecuteCUD(sql);
        }

        public void DeleteAdmin(Admin admin)
        {   //DELETE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Delete from Admin where admin_id =" + admin.adminID;
            sQLConfig.ExecuteCUD(sql);
        }

        public DataTable getAdmin()
        {
            SQLConfig sqlConfig = new SQLConfig();
            string sql = "Select admin_id, admin_title_id, admin_fullname, admin_nic, admin_email, admin_mobileno, admin_telephoneno from Admin";
            DataTable dt = sqlConfig.ExecuteSelect(sql);
            return dt;
        }

        public Admin getAdminByID(int adminId)
        {
            SQLConfig sqlConfig = new SQLConfig();
            string sql = "Select admin_title_id, admin_initial, admin_lname, admin_fullname, admin_dob, admin_nic, admin_passport, admin_email, admin_mobileno, " +
                "admin_telephoneno from Admin where admin_id =" + adminId;
            DataTable dt = sqlConfig.ExecuteSelect(sql);
            Admin admin = new Admin();

            foreach (DataRow dr in dt.Rows)
            {
                admin.adminTitleID = Convert.ToInt32(dr["admin_title_id"].ToString());
                admin.adminInitial = dr["admin_initial"].ToString();
                admin.adminLname = dr["admin_lname"].ToString();
                admin.adminFullname = dr["admin_fullname"].ToString();
                admin.adminDOB = Convert.ToDateTime(dr["admin_dob"].ToString());
                admin.adminNIC = dr["admin_nic"].ToString();
                admin.adminPassport = dr["admin_passport"].ToString();
                admin.adminEmail = dr["admin_email"].ToString();
                admin.adminMobileNo = dr["admin_mobileno"].ToString();
                admin.adminTelephoneNo = dr["admin_telephoneno"].ToString();
            }
            return admin;
        }
    }
}
