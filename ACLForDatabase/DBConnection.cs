/// Version 1.0
/// Author: Minh Nhat Trinh
/// Date 11/11/2017
/// Intention: writing a class (DBconnection) provides methods connecting to MySql
using System;
using MySql.Data.MySqlClient;

namespace ACLForDatabase{
    public class DBConnection : IDisposable{
        /// Attributies necessary: server, database, user name, password
        private string password;
        private string server;
        private string userName;
        private string database;
        public MySqlConnection Conn { get; private set; }
        /// Attributies to check whether or not connecting
        private string connString;
        private bool status;

        /// Contructor with plank String and status is "not connecting"
        public DBConnection(){
            password = string.Empty;
            server = string.Empty;
            userName = string.Empty;
            database = string.Empty;
            connString = string.Empty;
            connString = string.Empty;
            status = false;
        }
        
        /// Private method whose purpose is to connect parts of necessary arguments to connection string
        private void createConnectionString(){
            connString = "server="+server
                                +";database="+database
                                +";uid="+userName
                                +";password="+password;
        }

        /// make a connect to mySql and open it to new queries
        /// return false and send a message if there is any problem with connection
        /// return true if connection successful
        public bool Connect(){
            createConnectionString();
            try{
                Conn = new MySqlConnection(connString);
                Conn.Open();
                Console.WriteLine("Connection successful!");
            }   
            catch (Exception e){
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
            status = true;
            return true;
        }

        /// check whether or not a connection at the moment
        public bool IsConnect(){
            return status;
        }

        /// set password method
        public void SetPassword(string password){
            this.password = password;
        }
        
        /// set server method
        public void SetServer(string server){
            this.server = server;
        }

        /// set user name method
        public void SetUserName(string userName){
            this.userName = userName;
        }

        /// set database method
        public void SetDatabase(string database){
            this.database = database;
        }

        public void Dispose()
        {
            Conn.Dispose();
            status = false;
        }
    }
}
