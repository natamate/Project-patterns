using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using ACLDatabase.Model;

namespace ACLDatabase.Company.DB
{
    [Table("CompanyContext")]
    public class CompanyContext : ModelContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Financial> Financials { get; set; }
    }
}