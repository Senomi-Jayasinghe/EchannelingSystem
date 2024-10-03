using System;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;

namespace EchannelingSystem.Model
{
    public class AppCalendar
    {
        public int appCalendarID { get; set; }
        public int branchID { get; set; }
        public int consultantID { get; set; }
        public DateTime date {  get; set; }
        public string fromTime { get; set; }
        public string toTime { get; set; }
        public int webQuota { get; set; }
        public int offlineQuota { get; set; }
        public int balance {  get; set; }
        public string status { get; set; }
        public decimal consultationFee { get; set; }
        public int entryUser {  get; set; }
        public DateTime entryDate { get; set; }


    }
}
