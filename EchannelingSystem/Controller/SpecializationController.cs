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
    public class SpecializationController
    {
        public void SaveSpecialization(Specialization specialization)
        {//SAVE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "insert into Specialization(specialization_description) values ('" + specialization.specializationDescription + "')";

            sQLConfig.ExecuteCUD(sql);
        }

        public void UpdateSpecialization(Specialization specialization)
        {//UPDATE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Update Specialization set specialization_description= '" + specialization.specializationDescription 
                + "' where specialization_id=" + specialization.specializationID;
            sQLConfig.ExecuteCUD(sql);
        }

        public void DeleteSpecialization(Specialization specialization)
        {//DELETE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Delete from Specialization where specialization_id=" + specialization.specializationID;
            sQLConfig.ExecuteCUD(sql);
        }

        public DataTable getSpecialization()
        {//GET DATA TO DISPLAY IN GRID
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select specialization_id, specialization_description from Specialization ";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }

        public Specialization getSpecializationByID(int specializationId)
        {//GET DATA BY ID TO FILL FORM IN UPDATE AND DELETE MODE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select specialization_id, specialization_description from Specialization where specialization_id=" + specializationId;

            DataTable dt = sQLConfig.ExecuteSelect(sql);
            Specialization specialization = new Specialization();

            foreach (DataRow dr in dt.Rows)
            {
                specialization.specializationDescription= dr["specialization_description"].ToString();
            }
            return specialization;
        }
    }
}