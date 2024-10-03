using System;

namespace EchannelingSystem.Model
{
    [Serializable]
    public class Medicine
    {
        public int medicineID {  get; set; }
        public int medicineCategoryID { get; set; }
        public string medicineDescription { get; set; }
        public string medicineScientificName { get; set; }

    }
}
