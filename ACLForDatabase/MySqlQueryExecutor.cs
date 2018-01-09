using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ACLForDatabase
{
    public class MySqlQueryExecutor : IQueryExecutor
    {
        private readonly MySqlConnection _connection;

        public MySqlQueryExecutor(MySqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        [AuthorisationAspect]
        public DataTable ExecuteQuery(string commandText, IDBUser user)
        {

            var mySqlCommand = new MySqlCommand(commandText, _connection);
            var dbResponse = new DataTable();

            _connection.Open();
            dbResponse.Load(mySqlCommand.ExecuteReader());
            _connection.Close();

            return dbResponse;
        }
    }
}
