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

            CreateFin(1000.0, em1, context);
            CreateFin(1500.0, em1, context);
            CreateFin(1600.0, em1, context);

            CreateFin(600.0, em2, context);
            CreateFin(700.0, em2, context);
            CreateFin(800.0, em2, context);

            CreateFin(650.0, em31, context);
            CreateFin(750.0, em31, context);
            CreateFin(8500.0, em31, context);

            CreateFin(6510.0, em32, context);
            CreateFin(7510.0, em32, context);
            CreateFin(8510.0, em32, context);

            CreateFin(100.0, em4, context);
            CreateFin(200.0, em4, context);
            CreateFin(3000.0, em4, context);

            context.SaveChanges();
        }
    }
}