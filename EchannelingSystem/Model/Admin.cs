using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EchannelingSystem.Model
{
    public class Admin
    {
        public int adminID {  get; set; }
        public int adminTitleID { get; set; }
        public string adminInitial { get; set; }
        public string adminLname { get; set; }
        public string adminFullname { get; set; }
        public DateTime adminDOB { get; set; }
        public string adminNIC { get; set; }
        public string adminPassport { get; set; }
        public string adminEmail { get; set; }
        public string adminMobileNo { get; set; }
        public string adminTelephoneNo { get; set; }
        public int entryUser { get; set; }
        public DateTime entryDate { get; set; }
    }
}