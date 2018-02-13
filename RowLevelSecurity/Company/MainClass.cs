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
                var myUi = new ConsoleUi(myDb, drawingStrategy);
                Database.SetInitializer(new InitializeData());
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
