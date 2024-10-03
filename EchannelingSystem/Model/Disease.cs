using System;

namespace EchannelingSystem.Model
{
    [Serializable]
    public class Disease
    {
        public int diseaseID {  get; set; }
        public string diseaseName { get; set; }
        public string diseaseDescription { get; set; }

    }
}
