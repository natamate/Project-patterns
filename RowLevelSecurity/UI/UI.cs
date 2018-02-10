using System;
using ACLDatabase.Company.DB;
using ACLDatabase.Company;

namespace ACLDatabase.UI
{
    //Main interface user of Program
    //This class references to the component UI of the pattern MVC
    public class ConsoleUI
    {
        //Clear all components on interface
        public void ClearUI()
        {
            Console.Clear();
        }

        //Title of application
        public void GetGreetings()
        {
            Console.WriteLine("Wellcome to our application.");
        }

        //Get type of connection: normal authentication or aspect
        public string GetTypeOfConnection()
        {
            while (true)
            {
                Console.WriteLine("Select type to connect:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Normal");
                Console.WriteLine("2. AOP");
                var res = Console.ReadLine();
                if (res == "1" || res == "2")
                    return res;
                else if (res == "0")
                {
                    return "exit";
                }
                else
                {
                    Console.WriteLine("The selection should be a integer from 1 to 2");
                    continue;
                }
            }
            
        }

        //Get user method
        public string GetUser(CompanyContext c)
        {
            UserFactory uf = new UserFactory();
            while (true)
            {
                Console.WriteLine("Login as: ");
                Console.WriteLine("1. Boss");
                Console.WriteLine("2. Accountant");
                Console.WriteLine("3. Programmer");
                Console.WriteLine("4. Intern");
                Console.WriteLine("5. Test User");
                var res = Console.ReadLine();
                var user = uf.GetUser(res);
                if (user == null)
                {
                    Console.Clear();
                    Console.WriteLine("The selection should be a integer from 1 to 5");
                    continue;
                }
                return user;
            }
        }

        //print result on UI stream
        public void PrintData(CompanyContext context)
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
            Console.ReadLine();
        }
    }
}
