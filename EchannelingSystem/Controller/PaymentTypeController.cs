using EchannelingSystem.Database;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EchannelingSystem.Controller
{
    public class PaymentTypeController
    {
        public void SavePaymentType(PaymentType paymentType)
        {//SAVE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "insert into PaymentType(payment_type_description) values ('" + paymentType.paymentTypeDescription + "')";

            sQLConfig.ExecuteCUD(sql);
        }

        public void UpdatePaymentType(PaymentType paymentType)
        {//UPDATE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Update PaymentType set payment_type_description= '" + paymentType.paymentTypeDescription + "' where payment_type_id=" + paymentType.paymentTypeID;
            sQLConfig.ExecuteCUD(sql);
        }

        public void DeletePaymentType(PaymentType paymentType)
        {//DELETE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Delete from PaymentType where payment_type_id=" + paymentType.paymentTypeID;
            sQLConfig.ExecuteCUD(sql);
        }

        public DataTable getPaymentType()
        {//GET DATA TO DISPLAY IN GRID
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select payment_type_id, payment_type_description from PaymentType";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }

        public PaymentType getPaymentTypeByID(int paymentTypeId)
        {//GET DATA BY ID TO FILL FORM IN UPDATE AND DELETE MODE
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select payment_type_id, payment_type_description from PaymentType where payment_type_id=" + paymentTypeId;
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            PaymentType paymentType = new PaymentType();

            foreach (DataRow dr in dt.Rows)
            {
                paymentType.paymentTypeDescription = dr["payment_type_description"].ToString();
            }
            return paymentType;
        }
    }
}