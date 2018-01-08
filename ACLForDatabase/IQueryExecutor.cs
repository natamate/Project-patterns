using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLForDatabase
{
    public interface IQueryExecutor
    {
        [AuthorisationAspect]
        SqlDataReader ExecuteQuery(string queryText, IDBUser user);
    }
}
