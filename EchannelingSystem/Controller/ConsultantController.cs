using EchannelingSystem.Database;
using EchannelingSystem.Model;
using EchannelingSystem.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EchannelingSystem.Controller
{
    public class ConsultantController
    {
        public void SaveConsultant(Consultant consultant, List<Qualification> qualificationList, List<Specialization> specializationList, UserLogin userLogin)
        {   //INSERT TO CONSULTANT TABLE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "insert into Consultant(consultant_title, consultant_initial, consultant_lname, consultant_fullname, consultant_dob, " +
                "consultant_gender, consultant_register_id, consultant_address, consultant_contact_1, consultant_contact_2, consultant_email, " +
                "consultant_hospital, entry_user, entry_date) " + " " +
                "values (" + consultant.consultantTitle + ",'" + consultant.consultantInitial + "','" + consultant.consultantLname + "','"
                + consultant.consultantFullname + "','" + consultant.consultantDOB + "','" + consultant.consultantGender + "',"
                + consultant.consultantRegisterID + ",'" + consultant.consultantAddress + "','" + consultant.consultantContact1 + "','"
                + consultant.consultantContact2 + "','" + consultant.consultantEmail + "','" + consultant.consultantHospital + "',"
                + consultant.entryUser + ", '" + consultant.entryDate + "');" +
                " select CAST(scope_identity() as int)";
            //GET CONSULTANT ID
            int maxID = Convert.ToInt32(sQLConfig.InsertDataWithReturnId(sql));
            //INSERT QUALIFICATIONS
            foreach (var item in qualificationList)
            {
                string sqlQualification = "insert into ConsultantQualification(consultant_id,qualification_id) " +
                    "values(" + maxID + "," + item.qualificationID + ")";
                sQLConfig.ExecuteCUD(sqlQualification);
            }
            //INSERT SPECIALIZATIONS
            foreach (var item in specializationList)
            {
                string sqlSpecialization = "insert into ConsultantSpecialization(consultant_id,specialization_id) " +
                    "values(" + maxID + "," + item.specializationID + ")";
                sQLConfig.ExecuteCUD(sqlSpecialization);
            }

            string sqlLogin = "Insert into UserLogin(user_email, user_password, user_reference_id, user_role) values ('" + userLogin.userEmail + "','"
                + userLogin.userPassword + "'," + maxID + "," + 2 + ")";
            sQLConfig.ExecuteCUD(sqlLogin);
        }
        public void UpdateConsultant(Consultant consultant, List<Qualification> qualificationList, List<Specialization> specializationList)
        {   //UPDATE CONSULTANT
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Update Consultant set consultant_title= " + consultant.consultantTitle +
                ",consultant_initial= '" + consultant.consultantInitial + "',consultant_lname= '" + consultant.consultantLname +
                "',consultant_fullname= '" + consultant.consultantFullname + "',consultant_dob= '" + consultant.consultantDOB +
                "',consultant_gender= '" + consultant.consultantGender + "',consultant_register_id= " + consultant.consultantRegisterID +
                ",consultant_address= '" + consultant.consultantAddress + "',consultant_contact_1= '" + consultant.consultantContact1 +
                "',consultant_contact_2= '" + consultant.consultantContact2 + "',consultant_email= '" + consultant.consultantEmail +
                "',consultant_hospital= '" + consultant.consultantHospital + "', entry_user= " + consultant.entryUser + ", " +
                "entry_date= '" + consultant.entryDate + "' where consultant_id=" + consultant.consultantID;
            sQLConfig.ExecuteCUD(sql);
            //DELETE QUALIFICATIONS
            string sqlDeleteQualification = "Delete from ConsultantQualification where consultant_id =" + consultant.consultantID;
            sQLConfig.ExecuteCUD(sqlDeleteQualification);
            //REENTER UPDATED QUALIFICATION LIST
            foreach (var item in qualificationList)
            {
                string sqlQualification = "insert into ConsultantQualification (consultant_id,qualification_id) " +
                "values(" + consultant.consultantID + "," + item.qualificationID + ")";
                sQLConfig.ExecuteCUD(sqlQualification);
            }
            //DELETE SPECIALIZATIONS
            string sqlDeleteSpecialization = "Delete from ConsultantSpecialization where consultant_id =" + consultant.consultantID;
            sQLConfig.ExecuteCUD(sqlDeleteSpecialization);
            //REENTER UPDATED SPECIALIZATION LIST
            foreach (var item in specializationList)
            {
                string sqlSpecialization = "insert into ConsultantSpecialization (consultant_id,specialization_id) " +
                "values(" + consultant.consultantID + "," + item.specializationID + ")";
                sQLConfig.ExecuteCUD(sqlSpecialization);
            }
        }

        public void DeleteConsultant(Consultant consultant, List<Qualification> qualificationList, List<Specialization> specializationList)
        {   //DELETE CONSULTANT
            SQLConfig sQLConfig = new SQLConfig();

            string sqlDeleteQualification = "Delete from ConsultantQualification where consultant_id=" + consultant.consultantID;
            sQLConfig.ExecuteCUD(sqlDeleteQualification);

            string sqlDeleteSpecialization = "Delete from ConsultantSpecialization where consultant_id=" + consultant.consultantID;
            sQLConfig.ExecuteCUD(sqlDeleteSpecialization);

            string sqlDeleteConsultant = "Delete from Consultant where consultant_id=" + consultant.consultantID;
            sQLConfig.ExecuteCUD(sqlDeleteConsultant);
        }

        public DataTable getConsultant(Consultant consultant)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select consultant_id, consultant_fullname, consultant_register_id, consultant_contact_1, consultant_email, consultant_hospital" +
                " from Consultant where (consultant_initial='" + consultant.consultantInitial + "' OR ''= '" + consultant.consultantInitial + "') AND " +
                "(consultant_lname = '" + consultant.consultantLname + "' OR ''= '" + consultant.consultantLname + "') AND " +
                "(consultant_register_id ='" + consultant.consultantRegisterID + "' OR 0= " + consultant.consultantRegisterID + ") AND " +
                "(consultant_contact_1 ='" + consultant.consultantContact1 + "' OR consultant_contact_2 ='" + consultant.consultantContact1 + "' OR ''= '" + consultant.consultantContact1 + "') AND " +
                "(consultant_email ='" + consultant.consultantEmail + "' OR ''= '" + consultant.consultantEmail + "')";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }

        public (Consultant, List<Specialization>, List<Qualification>) getConsultantByID(int consultantId)
        {   //GET CONSULTANT BY ID FOR UPDATE AND DELETE FUNCTIONS
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select consultant_id,consultant_title, consultant_initial, consultant_lname, consultant_fullname, consultant_dob, " +
                "consultant_gender, consultant_register_id, consultant_address, consultant_contact_1, consultant_contact_2, consultant_email, " +
                "consultant_hospital from Consultant where consultant_id=" + consultantId;
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            Consultant consultant = new Consultant();

            foreach (DataRow dr in dt.Rows)
            {
                consultant.consultantTitle = Convert.ToInt32(dr["consultant_title"].ToString());
                consultant.consultantInitial = dr["consultant_initial"].ToString();
                consultant.consultantLname = dr["consultant_lname"].ToString();
                consultant.consultantFullname = dr["consultant_fullname"].ToString();
                consultant.consultantDOB = Convert.ToDateTime(dr["consultant_dob"].ToString());
                consultant.consultantGender = dr["consultant_gender"].ToString();
                consultant.consultantRegisterID = Convert.ToInt32(dr["consultant_register_id"].ToString());
                consultant.consultantAddress = dr["consultant_address"].ToString();
                consultant.consultantContact1 = dr["consultant_contact_1"].ToString();
                consultant.consultantContact2 = dr["consultant_contact_2"].ToString();
                consultant.consultantEmail = dr["consultant_email"].ToString();
                consultant.consultantHospital = dr["consultant_hospital"].ToString();
                consultant.consultantID = consultantId;
            }

            string sqlSpecialization = "Select s.specialization_id,s.specialization_description from ConsultantSpecialization cs Join Specialization s " +
            "ON cs.specialization_id = s.specialization_id WHERE cs.consultant_id =" + consultantId;
            DataTable dts = sQLConfig.ExecuteSelect(sqlSpecialization);
            List<Specialization> specializationList = new List<Specialization>();

            foreach (DataRow drs in dts.Rows)
            {
                Specialization specialization = new Specialization();
                specialization.specializationID = Convert.ToInt32(drs["specialization_id"].ToString());
                specialization.specializationDescription = drs["specialization_description"].ToString();
                specializationList.Add(specialization);
            }

            string sqlQualification = "Select q.qualification_id,q.qualification_description from ConsultantQualification cq Join Qualification q " +
                "ON cq.qualification_id = q.qualification_id WHERE cq.consultant_id =" + consultantId;
            DataTable dtq = sQLConfig.ExecuteSelect(sqlQualification);
            List<Qualification> qualificationList = new List<Qualification>();

            foreach (DataRow drq in dtq.Rows)
            {
                Qualification qualification = new Qualification();
                qualification.qualificationID = Convert.ToInt32(drq["qualification_id"].ToString());
                qualification.qualificationDescription = drq["qualification_description"].ToString();
                qualificationList.Add(qualification);
            }
            return (consultant, specializationList, qualificationList);
        }
    }
}