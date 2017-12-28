using System.Data.SqlClient;

namespace ACLForDatabase
{
    public interface IDatabaseUser
    {
        string GetUserName();
        string SetUser(string userName);
        SqlDataReader ExecuteUserQuerry(SqlConnection databaseConnectionb);
    }
}

