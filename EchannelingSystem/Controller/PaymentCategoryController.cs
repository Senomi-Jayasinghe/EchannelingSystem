using EchannelingSystem.Database;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EchannelingSystem.Controller
{
    public class PaymentCategoryController
    {
        public void SavePaymentCategory(PaymentCategory paymentCategory)
        {//SAVE PAYMENT CATEGORY
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "insert into PaymentCategory(category_description) values ('" + paymentCategory.categoryDescription + "')";
            sQLConfig.ExecuteCUD(sql);
        }

        public void UpdatePaymentCategory(PaymentCategory paymentCategory)
        {//UPDATE PAYMENT CATEGORY
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Update PaymentCategory set category_description= '" + paymentCategory.categoryDescription + "' where payment_category_id=" + paymentCategory.paymentCategoryID;
            sQLConfig.ExecuteCUD(sql);
        }

        public void DeletePaymentCategory(PaymentCategory paymentCategory)
        {//DELETE PAYMENT CATEGORY
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Delete from PaymentCategory where payment_category_id=" + paymentCategory.paymentCategoryID;
            sQLConfig.ExecuteCUD(sql);
        }

        public DataTable getPaymentCategory()
        {//SELECT PAYMENT CATEGORY TO DISPLAY IN GRID
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select payment_category_id, category_description from PaymentCategory";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }

        public PaymentCategory getPaymentCategoryByID(int paymentCategoryId)
        {//GET DATA BY ID TO FILL FORM IN UPDATE AND DELETE MODE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select payment_category_id, category_description from PaymentCategory where payment_category_id =" + paymentCategoryId;
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            PaymentCategory paymentCategory = new PaymentCategory();

            foreach (DataRow dr in dt.Rows)
            {
                paymentCategory.categoryDescription = dr["category_description"].ToString();
            }
            return paymentCategory;
        }
    }
}