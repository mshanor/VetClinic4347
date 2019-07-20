using System;
using System.Collections.Generic;

namespace VetClinic_Gui
{
    public partial class Species
    {
        public Species()
        {
            Patients = new HashSet<Patients>();
        }

        public string SpeciesId { get; set; }
        public string SpeciesName { get; set; }
        public string SpecialistId { get; set; }

        public virtual Doctor Specialist { get; set; }
        public virtual ICollection<Patients> Patients { get; set; }
    }
}
