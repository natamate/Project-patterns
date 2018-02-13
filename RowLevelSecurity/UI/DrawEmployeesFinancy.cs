using System;
using System.Linq;
using ACLDatabase.Company.DB;

namespace ACLDatabase.UI
{
    public class DrawEmployeesFinancy : IDrawingStrategy
    {
        public void DrawSpecificTable(CompanyContext context)
        {
            
            foreach (var tmpEmployee in context.Employees)
            {
                //printing employees table
                Console.WriteLine("{0,-4} {1,-10} {2,-15}",
                    "Id", "Name", "RoleId");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("{0,-4} {1,-10} {2,-15}",
                    tmpEmployee.EmployeeId, tmpEmployee.Name, tmpEmployee?.Role?.RoleId);
                Console.WriteLine("------------------------------------------------");

                //printing financials table
                Console.WriteLine("{0,-10} {1,-10} {2,-4}",
                    "EmployeeId", "Value", "RowId");
                Console.WriteLine("------------------------------------------------");
                foreach (var tmpFinancial in tmpEmployee.FinancialList)
                    Console.WriteLine("{0,-10} {1,-10} {2, -4}",
                        tmpFinancial.Employee.Name, tmpFinancial.Value, tmpFinancial.RowId);
                Console.WriteLine();
            }
        }

        public void SyncContextWithDb(CompanyContext context)
        {
            var queryRows = (from p in context.Rows select p).ToList();
            foreach (var row in context.Rows)
            {
                context.Rows.Remove(row);
            }
            context.Rows.AddRange(queryRows);
            var queryRowRoleDependencies = (from p in context.RowRoleDependencies select p).ToList();
            foreach (var rowRoleDependency in context.RowRoleDependencies)
            {
                context.RowRoleDependencies.Remove(rowRoleDependency);
            }
            context.RowRoleDependencies.AddRange(queryRowRoleDependencies);
            var queryRoles = (from p in context.Roles select p).ToList();
            foreach (var role in context.Roles)
            {
                context.Roles.Remove(role);
            }
            context.Roles.AddRange(queryRoles);
            var queryEmployees = (from p in context.Employees select p).ToList();
            foreach (var employee in context.Employees)
            {
                context.Employees.Remove(employee);
            }
            context.Employees.AddRange(queryEmployees);

            context.Roles.AddRange(queryRoles);
            var queryFinances = (from p in context.Financials select p).ToList();
            foreach (var financial in context.Financials)
            {
                context.Financials.Remove(financial);
            }
            context.Financials.AddRange(queryFinances);

        }
    }
}
