///Class for test function

using System;

namespace ACLForDatabase{
    public class MainClass{
        static void Main(string[] args){
            
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
