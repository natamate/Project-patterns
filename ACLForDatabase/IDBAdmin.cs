using System.Collections.Generic;
using System.Data.SqlClient;

namespace ACLForDatabase
{
    public interface IDBAdmin : IDBPrivilegesController
    {
        void AssignRoleToUser(IDBUser user, IDBRole role);
        void RenameUser(IDBUser user);
        void AddDatabaseUser(IDBUser user);
        IEnumerable<IDBUser> GetUsers(SqlConnection databaseConnectionb);
    }
}