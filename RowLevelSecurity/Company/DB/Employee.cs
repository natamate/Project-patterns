using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ACLDatabase.Model;

namespace ACLDatabase.Company.DB
{
    public class Employee
    {
        public Employee()
        {
            FinancialList = new List<Financial>();
        }

        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Role Role { get; set; }

        public virtual List<Financial> FinancialList { get; set; }
    }
}