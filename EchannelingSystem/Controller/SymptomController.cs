using EchannelingSystem.Database;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EchannelingSystem.Controller
{
    public class SymptomController
    {
        public void SaveSymptom(Symptom symptom)
        {//SAVE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "insert into Symptom(symptom_name, symptom_description) values ('" + symptom.symptomName + "', '" + symptom.symptomDescription + "')";

            sQLConfig.ExecuteCUD(sql);
        }

        public void UpdateSymptom(Symptom symptom)
        {//UPDATE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Update Symptom set symptom_name= '" + symptom.symptomName + "', symptom_description= '" + symptom.symptomDescription
                + "' where symptom_id=" + symptom.symptomID;
            sQLConfig.ExecuteCUD(sql);
        }

        public void DeleteSymptom(Symptom symptom)
        {//DELETE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Delete from Symptom where symptom_id=" + symptom.symptomID;
            sQLConfig.ExecuteCUD(sql);
        }

        public DataTable getSymptom()
        {//GET DATA TO DISPLAY IN GRID
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select symptom_id, symptom_name, symptom_description from Symptom ";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }

        public Symptom getSymptomByID(int symptomId)
        {//GET DATA BY ID TO FILL FORM IN UPDATE AND DELETE MODE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select symptom_id, symptom_name, symptom_description from Symptom where symptom_id=" + symptomId;
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            Symptom symptom = new Symptom();

            foreach (DataRow dr in dt.Rows)
            {
                symptom.symptomName = dr["symptom_name"].ToString();
                symptom.symptomDescription = dr["symptom_description"].ToString();
            }
            return symptom;
        }
    }
}