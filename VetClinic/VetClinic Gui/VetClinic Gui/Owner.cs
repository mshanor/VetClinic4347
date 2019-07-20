using System;
using System.Collections.Generic;

namespace VetClinic_Gui
{
    public partial class Owner
    {
        public Owner()
        {
            Patients = new HashSet<Patients>();
        }

        public string OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string AnimalId { get; set; }

        public virtual ICollection<Patients> Patients { get; set; }
    }
}
