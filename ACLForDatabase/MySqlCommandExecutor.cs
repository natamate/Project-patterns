using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ACLForDatabase
{
    public class MySqlCommandExecutor : ICommandExecutor<MySqlCommand>
    {
        private readonly MySqlConnection _connection;

        public MySqlCommandExecutor(MySqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public DataTable Execute(MySqlCommand command)
        {
            var mySqlCommand = new MySql.Data.MySqlClient.MySqlCommand(command.CommandText, _connection);
            var dbResponse = new DataTable();

            _connection.Open();
            dbResponse.Load(mySqlCommand.ExecuteReader());
            _connection.Close();

            return dbResponse;
        }
    }
}
