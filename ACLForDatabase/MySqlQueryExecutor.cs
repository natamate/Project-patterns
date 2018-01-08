using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PostSharp;

namespace ACLForDatabase
{
    public class MySqlQueryExecutor : IQueryExecutor
    {
        // connection must be opened before
        [AuthorisationAspect]
        public DataTable ExecuteQuery(string commandText, IDBUser user, MySqlConnection connection)
        {
            var mySqlCommand = new MySqlCommand(commandText, connection);
            var dbResponse = new DataTable();
            dbResponse.Load(mySqlCommand.ExecuteReader());

            return dbResponse;
        }
    }
}
