///Class for test function

using System;

namespace ACLForDatabase{
    public class main{
        static void Main(string[] args){
            DBConnection conn1 = new DBConnection();
            conn1.setServer("mysql.agh.edu.pl");
            conn1.setPassword("4zZMqXphDiKvEGmo");
            conn1.setUserName("trinh");
            conn1.setDatabase("trinh");
            if (conn1.connect() == false){
                Console.WriteLine("You are not in connection. Please check your instances");
            }else{
                Console.WriteLine("Connection ok");
            }
          
        }
    }
}
