using System.Data.Entity;
using ACLDatabase.Company.Auth;
using ACLDatabase.Company.DB;
using ACLDatabase.UI;

namespace ACLDatabase.Company
{
    //Main Class of the program
    //This class references to component Controller in pattern MVC
    public class MainClass
    {
        public static void Main(string[] args)
        {
            //Declaration for UI, Database, Model and Authentication
            ConsoleUI MyUI = new ConsoleUI();
            Database.SetInitializer(new InitializeData());
            Authentication MyAuth;
            AuthFactory MyAuthFactory = new AuthFactory();

            //Main program
            using (var MyDB = new CompanyContext())
            {
                while (true)
                {
                    MyUI.ClearUI();
                    MyUI.GetGreetings();
                    //From UI make a choice for type connection
                    string type = MyUI.GetTypeOfConnection();
                    if (type == "exit")
                        break;
                   
                    //Get type of Authentication by Factory
                    //1. Normal
                    //2. Aspect
                    MyAuth = MyAuthFactory.GetAuthentication(type);
                    
                    //From UI make a choice for user
                    var user = MyUI.GetUser(MyDB);

                    //Authenticate user
                    MyAuth.Authenticate(user, MyDB);

                    //Display data on the screen
                    MyUI.PrintData(MyDB);
                }
            }
        }

    }
}