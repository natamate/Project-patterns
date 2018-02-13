using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ACLDatabase.Model;

namespace ACLDatabase.Company.DB
{
    //Database Financial of Company
    //Database has Financialid, Amount of financial, EmployeeID
    //Database has key FinancialID, if foriegn key EmployeeID
    public class Financial : Row
    {
        [Key]
        public int FinancialId { get; set; }

        public double Value { get; set; }

        [ForeignKey("EmployeeRefId")]
        public virtual Employee Employee { get; set; }
    }
}