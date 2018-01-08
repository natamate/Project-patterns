using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ACLForDatabase
{
    class MySqlQueryExecutor : IQueryExecutor
    {
        // connection must be opened before
        [AuthorisationAspect]
        public MySqlDataReader ExecuteQuery(string commandText, IDBUser user, MySqlConnection connection)
        {
            var mySqlCommand = new MySqlCommand(commandText, connection);

            return mySqlCommand.ExecuteReader();
        }
    }
}
