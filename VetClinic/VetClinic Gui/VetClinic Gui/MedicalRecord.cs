using System;
using System.Collections.Generic;

namespace VetClinic_Gui
{
    public partial class MedicalRecord
    {
        public string AnimalId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }
        public string DateLastVisit { get; set; }
        public string Medicine { get; set; }
        public string RabiesShotDate { get; set; }
        public string Neutered { get; set; }
        public string HeartwormShotDate { get; set; }
        public string SpecialistId { get; set; }

        public virtual Doctor Specialist { get; set; }
    }
}
