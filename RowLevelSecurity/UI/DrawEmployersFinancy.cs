using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACLDatabase.Company.DB;

namespace ACLDatabase.UI
{
    public class DrawEmployersFinancy : IDrawingStrategy
    {
        public void DrawSpecificTable(CompanyContext context)
        {
            foreach (var TmpEmployee in context.Employees)
            {
                //printing employees table
                Console.WriteLine("{0,-4} {1,-10} {2,-15}",
                    "Id", "Name", "Role");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("{0,-4} {1,-10} {2,-15}",
                    TmpEmployee.EmployeeId, TmpEmployee.Name, TmpEmployee.Role);
                Console.WriteLine("------------------------------------------------");

                //printing financials table
                Console.WriteLine("{0,-10} {1,-10} {2,-4}",
                    "EmployeeId", "Value", "FinancialId");
                Console.WriteLine("------------------------------------------------");
                foreach (var TmpFinancial in TmpEmployee.FinancialList)
                    Console.WriteLine("{0,-10} {1,-10} {2, -4}",
                        TmpFinancial.EmployeeRefId, TmpFinancial.Value, TmpFinancial.FinancialId);
                Console.WriteLine();
            }
        }
    }
}
