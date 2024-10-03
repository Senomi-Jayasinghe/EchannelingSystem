using System;

namespace EchannelingSystem.Model
{
    [Serializable]
    public class Symptom
    {
        public int symptomID {  get; set; }
        public string symptomName { get; set; }
        public string symptomDescription { get; set; }

    }
}
