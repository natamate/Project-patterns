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
        [AuthorisationAspect]
        public SqlDataReader ExecuteQuery(string queryText, IDBUser user)
        {

            return null;
        }
    }
}
