using EchannelingSystem.Database;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace EchannelingSystem.Controller
{
    public class LabReportsController
    {
        public void SaveLabReports(LabReports labReports)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "insert into LabReports(report_description) values ('" + labReports.reportDescription + "')";

            sQLConfig.ExecuteCUD(sql);
        }

        public void UpdateLabReports(LabReports labReports)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Update LabReports set report_description = '" + labReports.reportDescription + "' where report_id=" + labReports.reportID;
            sQLConfig.ExecuteCUD(sql);
        }

        public void DeleteLabReports(LabReports labReports)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Delete from LabReports where report_id =" + labReports.reportID;
            sQLConfig.ExecuteCUD(sql);
        }

        public DataTable getLabReports()
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select report_id, report_description from LabReports";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }

        public LabReports getLabReportsByID(int reportId)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select report_id, report_description from LabReports where report_id=" + reportId;
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            LabReports labReports = new LabReports();

            foreach(DataRow dr in dt.Rows)
            {
                labReports.reportDescription = dr["report_description"].ToString();

            }

            return labReports;
        }
    }
}