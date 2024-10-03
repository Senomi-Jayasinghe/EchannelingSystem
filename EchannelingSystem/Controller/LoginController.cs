using EchannelingSystem.Database;
using EchannelingSystem.Model;
using EchannelingSystem.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace EchannelingSystem.Controller
{
    public class LoginController
    {
        public bool SearchUser(UserLogin userLogin) // Check if User Exists in System
        {
            SQLConfig sQLConfig = new SQLConfig();
            bool UserExist = false;
            string sql = "Select count(1) as Count from UserLogin where Upper(user_email) = '" + userLogin.userEmail.ToUpper()
                + "' AND user_password = '" + userLogin.userPassword + "'";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            UserExist = Convert.ToBoolean(dt.Rows[0]["Count"]);
            return UserExist;
        }

        public DataTable getUser(UserLogin userLogin) //Get User Details using credentials
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select user_role from UserLogin where Upper(user_email) = '" + userLogin.userEmail.ToUpper() + "'";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            int UserRole = Convert.ToInt32(dt.Rows[0]["user_role"]);

            string sqlgetUser;

            if (UserRole == 1)
            {
                sqlgetUser = "Select u.user_reference_id, u.user_role, p.patient_lname as user_name " +
                             "from Patient p Inner Join UserLogin u On Upper(p.patient_email) = Upper(u.user_email) " +
                             "where Upper(u.user_email) = '" + userLogin.userEmail.ToUpper() + "'";
            }
            else if (UserRole == 2)
            {
                sqlgetUser = "Select u.user_reference_id, u.user_role, c.consultant_lname as user_name " +
                             "from Consultant c Inner Join UserLogin u On Upper(c.consultant_email) = Upper(u.user_email)" +
                             "where Upper(u.user_email) = '" + userLogin.userEmail.ToUpper() + "'";
            }
            else
            {
                sqlgetUser = "Select u.user_reference_id, u.user_role, a.admin_lname as user_name " +
                             "from Admin a Inner Join UserLogin u On Upper(a.admin_email) = Upper(u.user_email)" +
                             "where Upper(u.user_email) = '" + userLogin.userEmail.ToUpper() + "'";
            }

            DataTable dtu = sQLConfig.ExecuteSelect(sqlgetUser);
            return dtu;
        }

        public void UpdatePassword(string NewPassword, int UserID, int RoleID)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Update UserLogin set user_password = '" + NewPassword
                + "' where user_reference_id =" + UserID + "AND user_role = " + RoleID;
            sQLConfig.ExecuteCUD(sql);
        }

        public void forgotpswupdate(string NewPassword, string UserName)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Update UserLogin set user_password = '" + NewPassword + "' where Upper(user_email) = '" + UserName.ToUpper() + "'";
            sQLConfig.ExecuteCUD(sql);
        }

        public bool getOldPassword(int UserID, int RoleID, string OldPassword)
        {
            SQLConfig sQLConfig = new SQLConfig();
            bool CorrectPsw = false;
            string sql = "Select count(1) as Count from UserLogin where user_reference_id = " + UserID
                + "AND user_role = " + RoleID + " AND user_password = '" + OldPassword + "'";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            CorrectPsw = Convert.ToBoolean(dt.Rows[0]["Count"]);

            return CorrectPsw;
        }

        public bool IsExistEmail(string Email)
        {
            SQLConfig sqlConfig = new SQLConfig();
            bool IsExistEmail = false;
            string sql = "Select count(1) as Count from UserLogin where Upper(user_email) = '" + Email.ToUpper()
                + "'";
            DataTable dt = sqlConfig.ExecuteSelect(sql);
            IsExistEmail = Convert.ToBoolean(dt.Rows[0]["Count"]);
            return IsExistEmail;
        }

        public void EnterDetails(Patient patient, UserLogin userLogin)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Insert into Patient(patient_initial, patient_lname, patient_email) " +
                "values ('" + patient.patientInitial + "','" + patient.patientLname + "','" + patient.patientEmail + "');" +
                "select CAST(scope_identity() as int)";
            int maxID = Convert.ToInt32(sQLConfig.InsertDataWithReturnId(sql));
            string sql1 = "Insert into UserLogin(user_email, user_password, user_reference_id, user_role) " +
                "values ('" + userLogin.userEmail + "','" + userLogin.userPassword + "'," + maxID + "," + 1 + ")";
            sQLConfig.ExecuteCUD(sql1);
        }
    }
}