using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ACLForDatabase
{
    public interface IQueryExecutor
    {
        // should be more generic return type!!!
        [AuthorisationAspect]
        MySqlDataReader ExecuteQuery(string queryText, IDBUser user, MySqlConnection connection);
    }
}
