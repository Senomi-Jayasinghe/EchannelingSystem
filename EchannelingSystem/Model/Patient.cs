using System;

namespace EchannelingSystem.Model
{
    public class Patient
    {
        public int patientID {  get; set; }
        public int? patientTitleID { get; set; }
        public string patientInitial {  get; set; }
        public string patientLname {  get; set; }
        public string patientFullname { get; set; }
        public DateTime patientDOB { get; set; }
        public string patientGender { get; set; }
        public string patientNIC { get; set; }
        public string patientPassport { get; set; }
        public string patientAddress { get; set; }
        public int patientDistrictID {  get; set; }
        public string patientEmail { get; set; }
        public string patientMobileNo { get; set; }
        public string patientTelephoneNo { get; set; }
        public string patientGeolocation {  get; set; }
        public int patientBranchID { get; set; }
        public int entryUser {  get; set; }
        public DateTime entryDate { get; set; }
    }
}
