using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ACLForDatabase
{
    public interface IQueryExecutor
    {
        //[AuthorisationAspect]
        DataTable ExecuteQuery(string queryText, IDBUser user);
    }
}
