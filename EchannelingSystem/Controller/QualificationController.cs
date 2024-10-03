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
    public class QualificationController
    {
        public void SaveQualification(Qualification qualification)
        {//SAVE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "insert into Qualification(qualification_description) values ('" + qualification.qualificationDescription + "')";

            sQLConfig.ExecuteCUD(sql);
        }

        public void UpdateQualification(Qualification qualification)
        {//UPDATE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Update Qualification set qualification_description= '" + qualification.qualificationDescription + "' where qualification_id="
                + qualification.qualificationID;
            sQLConfig.ExecuteCUD(sql);
        }

        public void DeleteQualification(Qualification qualification)
        {//DELETE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Delete from Qualification where qualification_id=" + qualification.qualificationID;
            sQLConfig.ExecuteCUD(sql);
        }

        public DataTable getQualification()
        {//GET DATA TO DISPLAY IN GRID
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select qualification_id, qualification_description from Qualification ";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }

        public Qualification getQualificationByID(int qualificationId)
        {//GET DATA BY ID TO FILL FORM IN UPDATE AND DELETE MODE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select qualification_id, qualification_description from Qualification Where qualification_id=" + qualificationId;
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            Qualification qualification = new Qualification();

            foreach (DataRow dr in dt.Rows)
            {
                qualification.qualificationDescription = dr["qualification_description"].ToString();
            }
            return qualification;
        }
    }
}
