using System;
using ACLDatabase.Company.DB;
using ACLDatabase.Model;

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
    }
}
