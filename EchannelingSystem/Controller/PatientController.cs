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
    public class PatientController
    {
        public void SavePatient(Patient patient)
        {   //INSERT
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "insert into Patient(patient_title_id, patient_initial, patient_lname, patient_fullname, patient_dob, patient_gender, " +
                "patient_nic, patient_passport, patient_address,  patient_district_id, patient_email, patient_mobileno, patient_telephoneno, " +
                "patient_geolocation, patient_branch_id) " +
                " values (" + patient.patientTitleID + ",'" + patient.patientInitial + "','" + patient.patientLname + "','" + patient.patientFullname
                + "','" + patient.patientDOB + "','" + patient.patientGender + "','" + patient.patientNIC + "','" + patient.patientPassport + "','"
                + patient.patientAddress + "'," + patient.patientDistrictID + ",'" + patient.patientEmail + "','" + patient.patientMobileNo + "','"
                + patient.patientTelephoneNo + "','" + patient.patientGeolocation + "'," + patient.patientBranchID + ")";
            sQLConfig.ExecuteCUD(sql);
        }

        public void UpdatePatient(Patient patient)
        {   //UPDATE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Update Patient set patient_title_id= " + patient.patientTitleID + ",patient_initial= '" + patient.patientInitial
                + "',patient_lname= '" + patient.patientLname + "',patient_fullname= '" + patient.patientFullname
                + "',patient_dob= '" + patient.patientDOB + "',patient_gender= '" + patient.patientGender + "',patient_nic= '" + patient.patientNIC
                + "',patient_passport= '" + patient.patientPassport + "',patient_address= '" + patient.patientAddress
                + "',patient_district_id= " + patient.patientDistrictID + ",patient_email= '" + patient.patientEmail
                + "',patient_mobileno= '" + patient.patientMobileNo + "',patient_telephoneno= '" + patient.patientTelephoneNo
                + "',patient_geolocation= '" + patient.patientGeolocation + "',patient_branch_id=" + patient.patientBranchID
                + " where patient_id=" + patient.patientID;
            sQLConfig.ExecuteCUD(sql);
        }

        public void DeletePatient(Patient patient)
        {   //DELETE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Delete from Patient where patient_id=" + patient.patientID;
            sQLConfig.ExecuteCUD(sql);
        }

        public DataTable getPatient(Patient patient)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select p.patient_id, p.patient_fullname, p.patient_nic , p.patient_passport , p.patient_email, p.patient_mobileno, " +
                "b.branch_name from Patient p Inner Join Branch b On p.patient_branch_id = b.branch_id " +
                "WHERE " +
                "(p.patient_initial ='" + patient.patientInitial + "' OR '' ='" + patient.patientInitial + "')" +
                "AND (p.patient_lname ='" + patient.patientLname + "' OR '' ='" + patient.patientLname + "')" +
                "AND (p.patient_nic ='" + patient.patientNIC + "' OR '' ='" + patient.patientNIC + "')" +
                "AND (p.patient_passport ='" + patient.patientPassport + "' OR '' ='" + patient.patientPassport + "')" +
                "AND (p.patient_email ='" + patient.patientEmail + "' OR '' ='" + patient.patientEmail + "')" +
                "AND (p.patient_mobileno ='" + patient.patientMobileNo + "' OR '' ='" + patient.patientMobileNo + "')" +
                "AND (p.patient_telephoneno ='" + patient.patientTelephoneNo + "' OR '' ='" + patient.patientTelephoneNo + "')";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;

        }

        public Patient getPatientByID(int patientId)
        {   //GET PATIENT BY ID FOR UPDATE AND DELETE FUNCTIONS
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select patient_id, patient_title_id, patient_initial, patient_lname, patient_fullname, patient_dob, patient_gender, " +
                "patient_nic, patient_passport, patient_address, patient_district_id, patient_email, patient_mobileno, patient_telephoneno, " +
                "patient_geolocation, patient_branch_id from Patient where patient_id =" + patientId;

            DataTable dt = sQLConfig.ExecuteSelect(sql);
            Patient patient = new Patient();

            foreach (DataRow dr in dt.Rows)
            {
                patient.patientTitleID = Convert.ToInt32(dr["patient_title_id"].ToString());
                patient.patientInitial = dr["patient_initial"].ToString();
                patient.patientLname = dr["patient_lname"].ToString();
                patient.patientFullname = dr["patient_fullname"].ToString();
                patient.patientDOB = Convert.ToDateTime(dr["patient_dob"].ToString());
                patient.patientGender = dr["patient_gender"].ToString();
                patient.patientNIC = dr["patient_nic"].ToString();
                patient.patientPassport = dr["patient_passport"].ToString();
                patient.patientAddress = dr["patient_address"].ToString();
                patient.patientDistrictID = Convert.ToInt32(dr["patient_district_id"].ToString());
                patient.patientEmail = dr["patient_email"].ToString();
                patient.patientMobileNo = dr["patient_mobileno"].ToString();
                patient.patientTelephoneNo = dr["patient_telephoneno"].ToString();
                patient.patientGeolocation = dr["patient_geolocation"].ToString();
                patient.patientBranchID = Convert.ToInt32(dr["patient_branch_id"].ToString());

            }
            return patient;
        }
    }
}