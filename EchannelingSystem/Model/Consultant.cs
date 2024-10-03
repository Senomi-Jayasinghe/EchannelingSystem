using System;

namespace EchannelingSystem.Model
{
    public class Consultant
    {
        public int consultantID {  get; set; }
        public int consultantTitle { get; set; }
        public string consultantInitial {  get; set; }
        public string consultantLname { get; set; }
        public string consultantFullname { get; set; }
        public string consultantGender { get; set; }
        public DateTime consultantDOB { get; set; }
        public int consultantRegisterID { get; set; }
        public string consultantAddress { get; set; }
        public string consultantContact1 { get; set; }
        public string consultantContact2 { get; set; }
        public string consultantEmail {  get; set; }
        public string consultantHospital { get; set; }
        public int entryUser {  get; set; }
        public DateTime entryDate { get; set; }

    }
}
