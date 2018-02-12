using System.Data.Entity;
using ACLDatabase.Model;

namespace ACLDatabase.Company.DB
{
    //Initialize data for both database and model.
    //The class inheritances DropCreateDatabaseAlways which is provided from Entity Framework
    //DropCreateDatabaseAlways: drop every table after each use, it means recreate all data and set seed for database
    public class InitializeData : DropCreateDatabaseAlways<CompanyContext>
    {
        public Employee CreateEmp(string name, string role, CompanyContext myContext, Role myRole)
        {
            var tmpEmployee = new Employee { Name = name, Role = myRole.RoleId };
            myContext.Employees.Add(tmpEmployee);

            var tmpRole = new RowRoles { RowId = tmpEmployee.RowId, RoleId = myRole.RoleId };
            myContext.RowRoles.Add(tmpRole);

            return tmpEmployee;
        }

        public Financial CreateFin(double val, Employee e, CompanyContext myContext, Role myRole)
        {
            var tmpEmployee = new Financial{Value = val,Employee = e,EmployeeRefId = e.EmployeeId};
            myContext.Financials.Add(tmpEmployee);

            var tmpRole = new RowRoles { RowId = tmpEmployee.RowId, RoleId = myRole.RoleId };
            myContext.RowRoles.Add(tmpRole);

            return tmpEmployee;
        }

        //Override for seed method which is required by DropCreateDatabaseAlways
        protected override void Seed(CompanyContext context)
        {
            var user1 = new User {Login = "Boss_login"};
            var user2 = new User {Login = "Accountant_login"};
            var user3 = new User {Login = "Programist_login"};
            var user4 = new User {Login = "Intern_login"};

            //test users
            var testUser = new User { Login = "Test_login" };

            var role1 = new Role {RoleId = "CEO"};
            var role2 = new Role {RoleId = "Accountant", ParentId = role1.RoleId};
            var role3 = new Role {RoleId = "Programist", ParentId = role2.RoleId};
            var role4 = new Role {RoleId = "Intern", ParentId = role3.RoleId};

            //test roles
            var testRole = new Role() { RoleId = "Test" };

            user1.Roles.Add(role1);
            user2.Roles.Add(role2);
            user3.Roles.Add(role3);
            user4.Roles.Add(role4);

            //test users - adding role to user
            testUser.Roles.Add(testRole);

            var em1 = CreateEmp("Trinh", "CEO", context, role1);
            var em2 = CreateEmp("Materek", "Accountant", context, role2);
            var em31 = CreateEmp("Jakubowski", "Programist", context, role3);
            var em32 = CreateEmp("Lisiecki", "Programist", context, role3);
            var em33 = CreateEmp("Mrowkojad", "Programist", context, role3);
            var em4 = CreateEmp("Kowalski", "Intern", context, role4);

            //test users employee
            var t1 = CreateEmp("Tester", "Tester", context, testRole);

            CreateFin(1000.0, em1, context, role1);
            CreateFin(1500.0, em1, context, role1);
            CreateFin(1600.0, em1, context, role1);

            CreateFin(600.0, em2, context, role2);
            CreateFin(700.0, em2, context, role2);
            CreateFin(800.0, em2, context, role2);

            CreateFin(650.0, em31, context, role3);
            CreateFin(750.0, em31, context, role3);
            CreateFin(8500.0, em31, context, role3);

            CreateFin(6510.0, em32, context, role3);
            CreateFin(7510.0, em32, context, role3);
            CreateFin(8510.0, em32, context, role3);

            CreateFin(6530.0, em33, context, role3);
            CreateFin(7530.0, em33, context, role3);
            CreateFin(8530.0, em33, context, role3);

            CreateFin(100.0, em4, context, role4);
            CreateFin(200.0, em4, context, role4);
            CreateFin(3000.0, em4, context, role4);

            CreateFin(10.0, t1, context, testRole);
            CreateFin(70.0, t1, context, testRole);

            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(user4);

            context.Users.Add(testUser);

            context.SaveChanges();
        }
    }
}