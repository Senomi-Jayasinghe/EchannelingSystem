using EchannelingSystem.Database;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EchannelingSystem.Controller
{
    public class MedicineController
    {
        public void SaveMedicine(Medicine medicine)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "insert into Medicine(medicine_description, medicine_scientificname, medicine_category_id) values ('" 
                + medicine.medicineDescription + "','" + medicine.medicineScientificName + "'," + medicine.medicineCategoryID + ")";

            sQLConfig.ExecuteCUD(sql);
        }

        public void UpdateMedicine(Medicine medicine)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Update Medicine set medicine_description= '" + medicine.medicineDescription + "',medicine_scientificname= '" 
                + medicine.medicineScientificName + "',medicine_category_id=" + medicine.medicineCategoryID + "where medicine_id=" + medicine.medicineID;

            sQLConfig.ExecuteCUD(sql);
        }

        public void DeleteMedicine(Medicine medicine)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Delete from Medicine where medicine_id=" + medicine.medicineID;
            sQLConfig.ExecuteCUD(sql);
        }

        public DataTable getMedicine()
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select m.medicine_id,m.medicine_description,m.medicine_scientificname,mc.medicine_category_description from Medicine m " +
                "Inner Join MedicineCategory mc On m.medicine_category_id = mc.medicine_category_id";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }

        public Medicine getMedicineByID(int medicineId)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select medicine_id, medicine_description, medicine_scientificname, medicine_category_id from Medicine where medicine_id = " + medicineId;
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            Medicine medicine = new Medicine();

            foreach (DataRow dr in dt.Rows)
            {
                medicine.medicineDescription = dr["medicine_description"].ToString();
                medicine.medicineScientificName = dr["medicine_scientificname"].ToString();
                medicine.medicineCategoryID = Convert.ToInt32(dr["medicine_category_id"].ToString());

            }
            return medicine;
        }

        public DataTable getMedicineInfo()
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select medicine_id, medicine_description from Medicine";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }
    }
}