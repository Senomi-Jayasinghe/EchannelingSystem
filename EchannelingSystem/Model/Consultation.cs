using System;
using System.Drawing;

namespace EchannelingSystem.Model
{
    public class Consultation
    {
        public int consultantID {  get; set; }
        public int appointmentID { get; set; }
        public DateTime nextVisit {  get; set; }
        public int entryUser {  get; set; }
        public DateTime entryDate { get; set; }

        
    } 
}
