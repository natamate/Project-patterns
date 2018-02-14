using System;
using ACLDatabase.Company.DB;
using System.Data.Entity;
using ACLDatabase.UI;

namespace ACLDatabase.Company
{
    public class MainClass
    {

        public static void Main(string[] args)
        {
            //Main program
            using (var myDb = new CompanyContext())
            {
                //Declaration for UI, Database, Model and IAuthentication
                var drawingStrategy = new DrawEmployeesFinancy();
                var syncStrategy = new SyncContextRefresh();

                var myUi = new ConsoleUi(myDb, drawingStrategy, syncStrategy);

                //initialization for databases
                var res = myUi.GetTypeInitialization();
                if (res == 0)
                {
                    Console.WriteLine("Remaining all data");
                }
                else
                {
                    Console.WriteLine("Drop all data, create default data");
                    Database.SetInitializer(new InitializeData());
                }
                Console.WriteLine("Press to continue mining data");
                Console.ReadLine();
                

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
