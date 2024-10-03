using System;

namespace EchannelingSystem.Model
{
    public class Appointment
    {
        public int appointmentID { get; set; }
        public int patientID { get; set; }
        public int consultantID { get; set; }
        public int appCalendarID { get; set; }
        public int appointmentSeq { get; set; }
        public string appointmentStatus { get; set; }
        public int paymentID { get; set; }
        public int entryUser {  get; set; }
        public DateTime entryDate { get; set; }

    }
}
