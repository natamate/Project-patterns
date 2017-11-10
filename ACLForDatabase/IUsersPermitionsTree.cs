using System.Data.SqlClient;

namespace ACLForDatabase
{
    public interface IUsersPermitionsTree
    {
        IUsersPermitionsTree BuildTree(SqlConnection databaseConnection);
    }
}