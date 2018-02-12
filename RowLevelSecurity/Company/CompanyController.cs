using System.Data.Entity;
using ACLDatabase.Company.Auth;
using ACLDatabase.Company.DB;
using ACLDatabase.Model;
using ACLDatabase.UI;

namespace ACLDatabase.Company
{
    //Main Class of the program
    //This class references to component Controller in pattern MVC
    public class CompanyController<T> where T : ModelContext
    {
        private IView view;
        private T context;

        public CompanyController(IView view, T context)
        {
            this.view = view;
            this.context = context;
        }

        public void SetView(IView view)
        {
            this.view = view;
        }

        public void SetModel(T context)
        {
            this.context = context;
        }

        public int DisplayFinancyFromEmployerView()
        {
            Authentication<T> MyAuth;
            AuthFactory<T> MyAuthFactory = new AuthFactory<T>();
            view.ClearView();
            view.DrawGreetings();
            //From UI make a choice for type connection
            string type = view.GetTypeOfConnection();
            if (type == "exit")
                return 1;

            //Get type of Authentication by Factory
            //1. Normal
            //2. Aspect
            MyAuth = MyAuthFactory.GetAuthentication(type);

            //From UI make a choice for user
            var user = view.GetUser();

            //Authenticate user
            MyAuth.Authenticate(user.Username,context);

            //Display data on the screen
            view.DrawTable();

            return 0;
        }

        public static void Main(string[] args)
        {
            //Main program
            using (var MyDB = new CompanyContext())
            {
                //Declaration for UI, Database, Model and Authentication
                var drawingStrategy = new DrawEmployersFinancy();
                var MyUI = new ConsoleUI(MyDB,drawingStrategy);
                Database.SetInitializer(new InitializeData());
                var controller = new CompanyController<CompanyContext>(MyUI, MyDB);

                while (true)
                {
                    if(controller.DisplayFinancyFromEmployerView() == 1)
                        break;
                }
            }
        }

    }
}