using ACLDatabase.Company.DB;
using System.Data.Entity;
using ACLDatabase.UI;
using System;

namespace ACLDatabase.Company
{
    public class MainClass
    {
        public static void Initialization()
        {
            Console.Clear();
            Console.WriteLine("Should drop and make default initialization?");
            Console.WriteLine("0. No");
            Console.WriteLine("1. Yes");
            var res = Console.ReadLine();
            switch (res)
            {
                case "0":
                    return;
                case "1":
                    Database.SetInitializer(new InitializeData());
                    return;
                default:
                    Initialization();
                    return;
            }


        }

        public static void Main(string[] args)
        {
            //Main program
            using (var myDb = new CompanyContext())
            {
                //Declaration for UI, Database, Model and IAuthentication
                var drawingStrategy = new DrawEmployeesFinancy();
                var myUi = new ConsoleUi(myDb, drawingStrategy);
                
                Initialization();
                var controller = new CompanyController<CompanyContext>(myUi, myDb);

                while (true)
                {
                    if (controller.DisplayFinancyFromEmployerView() == 1)
                        break;
                }
            }
        }
    }
}
