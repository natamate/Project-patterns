using System;
using ACLDatabase.Company.DB;
using ACLDatabase.Company;

namespace ACLDatabase.UI
{
    //Main interface user of Program
    //This class references to the component UI of the pattern MVC
    public class ConsoleUi : IView
    {
        private CompanyContext _context;
        private IDrawingStrategy _strategy;

        public ConsoleUi(CompanyContext context, IDrawingStrategy strategy)
        {
            _context = context;
            _strategy = strategy;
        }

        public void SetModel(CompanyContext context)
        {
            _context = context;
        }
        //Clear all components on interface
        public void ClearView()
        {
            Console.Clear();
        }

        public void SetDrawingStrategy(IDrawingStrategy strategy)
        {
            _strategy = strategy;
        }

        //Title of application
        public void DrawGreetings()
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
                switch (res)
                {
                    case "1":
                    case "2":
                        return res;
                    case "0":
                        return "exit";
                    default:
                        Console.WriteLine("The selection should be a integer from 1 to 2");
                        continue;
                }
            }
            
        }

        //Get user method
        public IUser GetUser()
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
        public void DrawTable()
        {
            Console.WriteLine();
            Console.WriteLine("There are");
            _strategy.DrawSpecificTable(_context);
            Console.ReadLine();
        }
    }
}
