using System.Data.Entity;
using ACLDatabase.Model;

namespace ACLDatabase.Company.DB
{
    public class InitializeData : DropCreateDatabaseAlways<CompanyContext>
    {
        public Employee CreateEmp(string name, CompanyContext myContext)
        {
            var newRole = new Role { RoleId = name};
            var tmpEmployee = new Employee { Name = name, Role = newRole};
            myContext.Employees.Add(tmpEmployee);
            myContext.Roles.Add(newRole);

            return tmpEmployee;
        }

        public void CreateParentChildRelation(Employee parent, Employee child)
        {
            child.Role.ParentId = parent.Role.RoleId;
        }

        public Financial CreateFin(double val, Employee e, CompanyContext myContext)
        {
            var createFin = new Financial{Value = val,Employee = e};
            myContext.Financials.Add(createFin);


            return createFin;
        }

        public RowRoleDependency AddRowPermition(Employee employee, Financial financial, CompanyContext myContext)
        {
            var dependency = new RowRoleDependency(financial.RowId, employee.Role);
            myContext.RowRoleDependencies.Add(dependency);
            return dependency;
        }

        //Override for seed method which is required by DropCreateDatabaseAlways
        protected override void Seed(CompanyContext context)
        {
            var em1 = CreateEmp("Trinh", context);
            var em2 = CreateEmp("Materek", context);
            var em31 = CreateEmp("Jakubowski",context);
            var em32 = CreateEmp("Lisiecki", context);
            var em4 = CreateEmp("Kowalski", context);

            CreateParentChildRelation(em1, em2);
            CreateParentChildRelation(em2, em31);
            CreateParentChildRelation(em2, em32);
            CreateParentChildRelation(em31, em4);

            var fin1 = CreateFin(1000.0, em1, context);
            var fin2 = CreateFin(600.0, em2, context);
            var fin31 = CreateFin(650.0, em31, context);
            var fin32 = CreateFin(6510.0, em32, context);
            var fin4 = CreateFin(100.0, em4, context);

            AddRowPermition(em1, fin1, context);
            AddRowPermition(em2, fin2, context);
            AddRowPermition(em31, fin31, context);
            AddRowPermition(em32, fin32, context);


            AddRowPermition(em4, fin4, context);

            context.SaveChanges();
        }
    }
}