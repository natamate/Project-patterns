///Class for test function

using System;
using SimpleInjector;
using System.Data;

namespace ACLForDatabase{
    public class MainClass{
        static void Main(string[] args){
            
            var container = new Container();

            // Go look in all assemblies and register all implementations
            // of ICommandExecutor<T> by their closed interface:
            container.Register(typeof(ICommandExecutor<>),
                new[] { typeof(ICommandExecutor<>).Assembly });

            // Decorates all executors with an authorization decorator.
            container.RegisterDecorator(typeof(ICommandExecutor<>),
                typeof(AuthorizationCommandExecutorDecorator<>));

            container.Verify();
            
            var server = "mysql.agh.edu.pl";
            var password = "nLrCdGx7nDhP5ymQ";
            var userName = "marcjaku";
            var database = "marcjaku";

            var role = new  MySqlRole(6,"director",null);
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
                    var command = new MySqlCommand("select * from templateTable;", user);



                    //var commandExecutor = container.GetInstance<MySqlCommandExecutor>();
                    //var executor = new MySqlCommandExecutor();
                    //executor.Connection = conn1.Connection;
                    //var commandExecutor = new AuthorizationCommandExecutorDecorator<MySqlCommand>(executor);
                    var commandExecutor = container.GetInstance<MySqlCommandExecutor>();
                    commandExecutor.Connection = conn1.Connection;


                    var res = commandExecutor.Execute(command);

                    foreach (DataRow row in res.Rows)
                    {
                        Console.WriteLine(row.Field<string>(2));
                    }
                    System.Console.ReadLine();
                }
            }
            
          
        }
    }
}
