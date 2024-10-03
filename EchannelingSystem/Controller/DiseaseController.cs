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
    public class DiseaseController
    {
        public void SaveDisease(Disease disease, List<Symptom> symptomList)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "insert into Disease(disease_name, disease_description) values ('" + disease.diseaseName + "', '" + disease.diseaseDescription + "'); " +
                "select CAST(scope_identity() as int)";

            int maxID = Convert.ToInt32(sQLConfig.InsertDataWithReturnId(sql));

            foreach (var item in symptomList)
            {
                string sqlSymptom = "insert into DiseaseSymptom(disease_id,symptom_id) " +
                    "values(" + maxID + "," + item.symptomID + ")";
                sQLConfig.ExecuteCUD(sqlSymptom);
            }
        }

        public void UpdateDisease(Disease disease, List<Symptom> symptomList)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Update Disease set disease_name = '" + disease.diseaseName + "', disease_description= '" + disease.diseaseDescription 
                + "' where disease_id=" + disease.diseaseID;
            sQLConfig.ExecuteCUD(sql);

            string sqlDeleteSymptom = "Delete from DiseaseSymptom where disease_id =" + disease.diseaseID;
            sQLConfig.ExecuteCUD(sqlDeleteSymptom);

            foreach (var item in symptomList)
            {
                string sqlSymptom = "insert into DiseaseSymptom(disease_id,symptom_id) " +
                    "values(" + disease.diseaseID + "," + item.symptomID + ")";
                sQLConfig.ExecuteCUD(sqlSymptom);
            }
        }

        public void DeleteDisease(Disease disease)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Delete from Disease where disease_id=" + disease.diseaseID;
            sQLConfig.ExecuteCUD(sql);

            string sqlDeleteSymptom = "Delete from DiseaseSymptom where disease_id=" + disease.diseaseID;
            sQLConfig.ExecuteCUD(sqlDeleteSymptom);
        }

        public DataTable getDisease()
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select disease_id, disease_name, disease_description from Disease";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }

        public (Disease, List<Symptom>) getDiseaseByID(int diseaseId)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select disease_id, disease_name, disease_description from Disease where disease_id=" + diseaseId;
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            Disease disease = new Disease();

            foreach (DataRow dr in dt.Rows)
            {
                disease.diseaseName= dr["disease_name"].ToString();
                disease.diseaseDescription = dr["disease_description"].ToString();

            }

            string sqlSymptom = "Select s.symptom_id,s.symptom_name from DiseaseSymptom ds Join Symptom s " +
            "ON ds.symptom_id = s.symptom_id WHERE ds.disease_id =" + diseaseId;
            DataTable dts = sQLConfig.ExecuteSelect(sqlSymptom);
            List<Symptom> symptomList = new List<Symptom>();

            foreach (DataRow drs in dts.Rows)
            {
                Symptom symptom = new Symptom();
                symptom.symptomID = Convert.ToInt32(drs["symptom_id"].ToString());
                symptom.symptomName = drs["symptom_name"].ToString();
                symptomList.Add(symptom);
            }
            return (disease, symptomList);
        }
    }
}