using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ACLForDatabase
{
    public class MySqlCommandExecutor : ICommandExecutor<MySqlCommand>
    {
        public MySqlConnection Connection { get; set; }

        public DataTable Execute(MySqlCommand command)
        {
            var mySqlCommand = new MySql.Data.MySqlClient.MySqlCommand(command.CommandText, Connection);
            var dbResponse = new DataTable();

            //_connection.Open();
            dbResponse.Load(mySqlCommand.ExecuteReader());
            //_connection.Close();

            return dbResponse;
        }
    }
}
