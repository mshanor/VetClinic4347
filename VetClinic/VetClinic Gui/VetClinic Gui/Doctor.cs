using System;
using System.Collections.Generic;

namespace VetClinic_Gui
{
    public partial class Doctor
    {
        public Doctor()
        {
            MedicalRecord = new HashSet<MedicalRecord>();
            Species = new HashSet<Species>();
        }

        public string SpecialistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public virtual Employee Specialist { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecord { get; set; }
        public virtual ICollection<Species> Species { get; set; }
    }
}
