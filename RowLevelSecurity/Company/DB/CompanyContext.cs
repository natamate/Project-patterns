using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using ACLDatabase.Model;

namespace ACLDatabase.Company.DB
{
    //Context for database of company
    //Behavior like a table in databse
    //Contains two DbSets Employee and Financials
    //Method inheritances from row securityContext
    [Table("CompanyContext")]
    public class CompanyContext : ModelContext {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Financial> Financials { get; set; }
    }
}