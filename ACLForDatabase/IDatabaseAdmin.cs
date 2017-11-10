using System.Collections.Generic;
using System.Data.SqlClient;

namespace ACLForDatabase
{
    public interface IDatabaseAdmin: IDatabasePermitionsControler
    {

        void RenameUser(IDatabaseUser user);
        void AddDatabaseUser(string uniqueUserName);
        IEnumerable<IDatabaseUser> GetUsers(SqlConnection databaseConnectionb);
    }
}