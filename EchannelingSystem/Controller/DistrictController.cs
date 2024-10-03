using EchannelingSystem.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EchannelingSystem.Controller
{
    public class DistrictController
    {
        public DataTable GetDistrict()
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select district_id, district_description from District";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }
    }
}