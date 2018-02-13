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
            myContext.SaveChanges();

            return createFin;
        }

        public RowRoleDependency AddRowPermition(Employee employee, Financial financial, CompanyContext myContext)
        {
            var dependency = new RowRoleDependency(financial.RowId, employee.Role);
            myContext.RowRoleDependencies.Add(dependency);
            return dependency;
        }

        protected override void Seed(CompanyContext context)
        {
            var em1 = CreateEmp("Trinh", context);
            var em2 = CreateEmp("Materek", context);
            var em31 = CreateEmp("Jakubowski", context);
            var em32 = CreateEmp("Lisiecki", context);
            var em4 = CreateEmp("Kowalski", context);

            CreateParentChildRelation(em1, em2);
            CreateParentChildRelation(em2, em31);
            CreateParentChildRelation(em2, em32);
            CreateParentChildRelation(em31, em4);

            var fin1A = CreateFin(1.0, em1, context);
            var fin1B = CreateFin(1.0, em1, context);
            var fin1C = CreateFin(1.0, em1, context);
            var fin1D = CreateFin(1.0, em1, context);
            var fin1E = CreateFin(1.0, em1, context);

            var fin2A = CreateFin(2.0, em2, context);
            var fin2B = CreateFin(2.0, em2, context);
            var fin2C = CreateFin(2.0, em2, context);
            var fin2D = CreateFin(2.0, em2, context);
            var fin2E = CreateFin(2.0, em2, context);

            var fin31A = CreateFin(31.0, em31, context);
            var fin31B = CreateFin(31.0, em31, context);
            var fin31C = CreateFin(31.0, em31, context);
            var fin31D = CreateFin(31.0, em31, context);
            var fin31E = CreateFin(31.0, em31, context);

            var fin32A = CreateFin(32.0, em32, context);
            var fin32B = CreateFin(32.0, em32, context);
            var fin32C = CreateFin(32.0, em32, context);
            var fin32D = CreateFin(32.0, em32, context);
            var fin32E = CreateFin(32.0, em32, context);

            var fin4A = CreateFin(4.0, em4, context);
            var fin4B = CreateFin(4.0, em4, context);
            var fin4C = CreateFin(4.0, em4, context);
            var fin4D = CreateFin(4.0, em4, context);
            var fin4E = CreateFin(4.0, em4, context);


            AddRowPermition(em1, fin1A, context);
            AddRowPermition(em1, fin1B, context);
            AddRowPermition(em1, fin1C, context);
            AddRowPermition(em1, fin1D, context);
            AddRowPermition(em1, fin1E, context);

            AddRowPermition(em2, fin2A, context);
            AddRowPermition(em2, fin2B, context);
            AddRowPermition(em2, fin2C, context);
            AddRowPermition(em2, fin2D, context);
            AddRowPermition(em2, fin2E, context);
            AddRowPermition(em2, fin31A, context);
            AddRowPermition(em2, fin31B, context);
            AddRowPermition(em2, fin31C, context);
            AddRowPermition(em2, fin31D, context);
            AddRowPermition(em2, fin31E, context);

            AddRowPermition(em31, fin31A, context);
            AddRowPermition(em31, fin31B, context);
            AddRowPermition(em31, fin31C, context);
            AddRowPermition(em31, fin31D, context);
            AddRowPermition(em31, fin31E, context);

            AddRowPermition(em32, fin32A, context);
            AddRowPermition(em32, fin32B, context);
            AddRowPermition(em32, fin32C, context);
            AddRowPermition(em32, fin32D, context);
            AddRowPermition(em32, fin32E, context);

            AddRowPermition(em4, fin4A, context);
            AddRowPermition(em4, fin4B, context);
            AddRowPermition(em4, fin4C, context);
            AddRowPermition(em4, fin4D, context);
            AddRowPermition(em4, fin4E, context);

            context.SaveChanges();
        }
    }
}