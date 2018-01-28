///Class for test function

using System;
using SimpleInjector;

namespace ACLForDatabase{
    public class MainClass{
        static void Main(string[] args){
            var container = new Container();

            // Go look in all assemblies and register all implementations
            // of ICommandExecutor<T> by their closed interface:
            container.Register(typeof(ICommandExecutor<>),
                AppDomain.CurrentDomain.GetAssemblies());

            // Decorates all executors with an authorization decorator.
            container.RegisterDecorator(typeof(ICommandExecutor<>),
                typeof(AuthorizationCommandExecutorDecorator<>));

            var server = "mysql.agh.edu.pl";
            var password = "nLrCdGx7nDhP5ymQ";
            var userName = "marcjaku";
            var database = "marcjaku";

            var role = new  MySqlRole(1,"manager",null);
            var user = new MySqlUser(1,"Zdzisek",role,false);

            using (DBConnection conn1 = new DBConnection(server, database, userName, password))
            {
                if (conn1.Connect() == false)
                {
                    Console.WriteLine("You are not in connection. Please check your instances");
                }
                else
                {
                    Console.WriteLine("Connection ok");
                    var command = new MySqlCommand("select example from templateTable;", user);
                    var commandExecutor = new MySqlCommandExecutor(conn1.Connection);
                    var res = commandExecutor.Execute(command);

                    System.Console.WriteLine(res.Rows.GetEnumerator().Current);
                    System.Console.ReadLine();
                }
            }
            
          
        }
    }
}
