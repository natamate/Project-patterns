using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ACLDatabase.Model;

namespace ACLDatabase.Company.DB
{
    //Database Employee
    //Each employee has EmployeeId, Name, Role and financialList
    //EmployeeId is key of database
    public class Employee : Row
    {
        public Employee()
        {
            FinancialList = new List<Financial>();
        }

        [Key]
        public int EmployeeId { get; set; }

        public string Name { get; set; }
        public Role Role { get; set; }

        public virtual List<Financial> FinancialList { get; set; }
    }
}