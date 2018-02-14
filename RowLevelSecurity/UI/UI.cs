using System;
using ACLDatabase.Company;
using ACLDatabase.Company.DB;

namespace ACLDatabase.UI
{
    //Main interface user of Program
    //This class references to the component UI of the pattern MVC
    public class ConsoleUi : IView
    {
        private CompanyContext _context;
        private IDrawingStrategy _viewStrategy;
        private ISyncContextStrategy _syncStrategy;

        public int GetMainInterface()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Option?");
                Console.WriteLine("0. Add role permission to row");
                Console.WriteLine("1. Remove role permission from row");
                Console.WriteLine("2. Show financies");
                var res = Console.ReadLine();
                switch (res)
                {
                    case "0":
                        return 0;
                    case "1":
                        return 1;
                    case "2":
                        return 2;
                    default:
                        Console.WriteLine("Should be a number 0 or 2");
                        continue;
                }
            }
        }

        public int GetTypeInitialization()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Should drop and make default initialization?");
                Console.WriteLine("0. No");
                Console.WriteLine("1. Yes");
                var res = Console.ReadLine();
                switch (res)
                {
                    case "0":
                        return 0;
                    case "1":
                        return 1;
                    default:
                        Console.WriteLine("Should be a number 0 or 1");
                        continue;
                }
            }
        }

    public ConsoleUi(CompanyContext context, IDrawingStrategy viewStrategy, ISyncContextStrategy syncStrategy)
    {
        _context = context;
        _viewStrategy = viewStrategy;
        _syncStrategy = syncStrategy;
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

    public void SetDrawingStrategy(IDrawingStrategy viewStrategy)
    {
        _viewStrategy = viewStrategy;
    }

    public void SetSynContextStrategy(ISyncContextStrategy syncStrategy)
    {
        _syncStrategy = syncStrategy;
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
            Console.WriteLine("1. Trinh");
            Console.WriteLine("2. Materek");
            Console.WriteLine("3. Jakubowski");
            Console.WriteLine("4. Lisiecki");
            Console.WriteLine("5. Kowalski");
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
        _syncStrategy.SyncContextWithDb(_context);
        _viewStrategy.DrawSpecificTable(_context);
        Console.ReadLine();
    }
}
}
