using ACLDatabase.Company.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACLDatabase.UI;

namespace ACLDatabase.Company
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            //Main program
            using (var MyDB = new CompanyContext())
            {
                //Declaration for UI, Database, Model and IAuthentication
                var drawingStrategy = new DrawEmployersFinancy();
                var MyUI = new ConsoleUI(MyDB, drawingStrategy);
                Database.SetInitializer(new InitializeData());
                var controller = new CompanyController<CompanyContext>(MyUI, MyDB);

                while (true)
                {
                    if (controller.DisplayFinancyFromEmployerView() == 1)
                        break;
                }
            }
        }
    }
}
