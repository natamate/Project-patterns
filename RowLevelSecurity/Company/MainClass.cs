using System;
using ACLDatabase.Company.DB;
using System.Data.Entity;
using ACLDatabase.UI;

namespace ACLDatabase.Company
{
    public class MainClass
    {
        public static void DbInitialization()
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
                    DbInitialization();
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
                var syncStrategy = new SyncContextRefresh();
                DbInitialization();
                var myUi = new ConsoleUi(myDb, drawingStrategy, syncStrategy);
             
                var controller = new CompanyController<CompanyContext>(myUi, myDb);
                
                while (true)
                {
                    if (controller.DisplayFinancyFromEmployerView() == 1)
                        break;
                    Console.WriteLine("Koniec wypisywania");
                }
            }
        }
    }
}
