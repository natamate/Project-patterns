using System.Data.SqlClient;
using System.Dynamic;
using Castle.DynamicProxy;
using MySql.Data.MySqlClient;

namespace ACLForDatabase
{   
    public interface IDBUser
    {
        int UserId { get;}
        string UserName { get; }
        IDBRole UserRole { get; }

        SqlDataReader ExecuteUserQuery(SqlConnection dbConnection,
                                       SqlCommand command, 
                                       DbPrivilegeType neededPrivilege);
    }
}
