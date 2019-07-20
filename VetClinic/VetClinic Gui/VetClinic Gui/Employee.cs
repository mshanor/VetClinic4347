using System;
using System.Collections.Generic;

namespace VetClinic_Gui
{
    public partial class Employee
    {
        public Employee()
        {
            InverseManager = new HashSet<Employee>();
        }

        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ManagerId { get; set; }
        public string Address { get; set; }

        public virtual Employee Manager { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<Employee> InverseManager { get; set; }
    }
}
