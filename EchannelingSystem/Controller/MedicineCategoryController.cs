using EchannelingSystem.Database;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EchannelingSystem.Controller
{
    public class MedicineCategoryController
    {
        public void SaveMedicineCategory(MedicineCategory medicineCategory)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "insert into MedicineCategory(medicine_category_description) values ('" + medicineCategory.medicineCategoryDescription + "')";

            sQLConfig.ExecuteCUD(sql);
        }

        public void UpdateMedicineCategory(MedicineCategory medicineCategory)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Update MedicineCategory set medicine_category_description= '" + medicineCategory.medicineCategoryDescription 
                + "' where medicine_category_id =" + medicineCategory.medicineCategoryID;
            sQLConfig.ExecuteCUD(sql);
        }

        public void DeleteMedicineCategory(MedicineCategory medicineCategory)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Delete from MedicineCategory where medicine_category_id =" + medicineCategory.medicineCategoryID;
            sQLConfig.ExecuteCUD(sql);
        }

        public DataTable getMedicineCategory()
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select medicine_category_id, medicine_category_description from MedicineCategory";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }

        public MedicineCategory getMedicineCategoryByID(int medicineCategoryId)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select medicine_category_id, medicine_category_description from MedicineCategory where medicine_category_id=" + medicineCategoryId;
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            MedicineCategory medicineCategory = new MedicineCategory();

            foreach (DataRow dr in dt.Rows)
            {
                medicineCategory.medicineCategoryDescription= dr["medicine_category_description"].ToString();

            }

            return medicineCategory;
        }
    }
}