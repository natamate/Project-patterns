using System.Data.SqlClient;
using System.Security.Principal;

namespace ACLForDatabase
{
    public interface IDBPrivilegesController
    {
        void AddPrivilegesToRole(SqlConnection connection, DBPrivilegeType privileges);
        void RemovePrivilegeFromRole(SqlConnection connection, IDBRole role, 
                                     SqlCommand sqlCommand);
    }
}
