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
            var password = "4zZMqXphDiKvEGmo";
            var userName = "trinh";
            var database = "trinh";

            using (DBConnection conn1 = new DBConnection(server, database, userName, database))
            {
                if (conn1.Connect() == false)
                {
                    Console.WriteLine("You are not in connection. Please check your instances");
                }
                else
                {
                    Console.WriteLine("Connection ok");
                }
            }
            
          
        }
    }
}
