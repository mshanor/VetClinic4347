using System;
using System.Collections.Generic;

namespace VetClinic_Gui
{
    public partial class Patients
    {
        public string AnimalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OwnerId { get; set; }
        public string SpeciesId { get; set; }

        public virtual Owner Owner { get; set; }
        public virtual Species Species { get; set; }
    }
}
