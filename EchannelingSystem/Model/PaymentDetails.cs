using System;

namespace EchannelingSystem.Model
{
    public class PaymentDetails
    {
        public int paymentID {  get; set; }
        public int paymentBranchID { get; set; }
        public int paymentCategoryID { get; set; }
        public decimal paymentAmount { get; set; }
        public int paymentTypeID { get; set; }
        public string paymentStatus { get; set; }
        public int entryUser {  get; set; }
        public string entryDate { get; set; }

    }
}
