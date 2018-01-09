/// Version 1.0
/// Author: Minh Nhat Trinh
/// Date 11/11/2017
/// Intention: writing a class (DBconnection) provides methods connecting to MySql
using System;
using MySql.Data.MySqlClient;

namespace ACLForDatabase{
    public class DBConnection : IDisposable{
        /// Attributies necessary: Server, Database, user name, Password
        public string Password { get; }
        public string Server { get; }
        public string UserName { get; }
        public string Database { get; }
        public MySqlConnection Connection { get; private set; }

        /// Attributies to check whether or not connecting
        private string _connString;
        private bool _status;

        public DBConnection(string server, string database, string userName, string password)
        {
            Server = server;
            Database = database;
            UserName = userName;
            Password = password;
        }

        
        /// Private method whose purpose is to connect parts of necessary arguments to connection string
        private void CreateConnectionString(){
            _connString = "Server="+Server
                                +";Database="+Database
                                +";uid="+UserName
                                +";Password="+Password;
        }

        /// make a connect to mySql and open it to new queries
        /// return false and send a message if there is any problem with connection
        /// return true if connection successful
        public bool Connect(){
            CreateConnectionString();
            try{
                Connection = new MySqlConnection(_connString);
                Connection.Open();
                Console.WriteLine("Connection successful!");
            }   
            catch (Exception e){
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
            _status = true;
            return true;
        }

        /// check whether or not a connection at the moment
        public bool IsConnect(){
            return _status;
        }

        public void Dispose()
        {
            Connection.Dispose();
            _status = false;
        }
    }
}
