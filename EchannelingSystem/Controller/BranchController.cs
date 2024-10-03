using EchannelingSystem.Database;
using EchannelingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EchannelingSystem.Controller
{
    public class BranchController
    {
        public void SaveBranch(Branch branch)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "insert into Branch(branch_name, branch_address, branch_email, branch_contact, branch_contact_person) " +
                "values ('" + branch.branchName + "','" + branch.branchAddress + "','" + branch.branchEmail + "','"
                + branch.branchContact + "','" + branch.branchContactPerson + "')";
            sQLConfig.InsertDataWithReturnId(sql);
        }

        public void UpdateBranch(Branch branch)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Update Branch set branch_name= '" + branch.branchName + "',branch_address= '" + branch.branchAddress
                + "',branch_email= '" + branch.branchEmail + "',branch_contact= '" + branch.branchContact + "',branch_contact_person= '" 
                + branch.branchContactPerson + "' where branch_id="+ branch.branchID;
            sQLConfig.ExecuteCUD(sql);
        }

        public void DeleteBranch(Branch branch)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Delete from Branch where branch_id=" + branch.branchID;
            sQLConfig.ExecuteCUD(sql);
        }

        public DataTable getBranch()
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select branch_id,branch_name, branch_address, branch_email, branch_contact, branch_contact_person from Branch ";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }

        public Branch getBranchByID(int branchId)
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select branch_id,branch_name, branch_address, branch_email, branch_contact, branch_contact_person " +
                         "from Branch Where branch_id=" + branchId;
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            Branch branch = new Branch();

            foreach (DataRow dr in dt.Rows)
            {
                branch.branchName= dr["branch_name"].ToString(); 
                branch.branchAddress = dr["branch_address"].ToString();
                branch.branchEmail = dr["branch_email"].ToString();
                branch.branchContact = dr["branch_contact"].ToString();
                branch.branchContactPerson = dr["branch_contact_person"].ToString();   
            }
            return branch;
        }

        public DataTable GetBranch()
        {
            SQLConfig sQLConfig = new SQLConfig();
            string sql = "Select branch_id, branch_name from Branch";
            DataTable dt = sQLConfig.ExecuteSelect(sql);
            return dt;
        }
    

    }
}