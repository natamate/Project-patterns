using System.Data.SqlClient;
namespace ACLForDatabase
{
    public interface IDatabasePermitionsControler
    {
        void AddPermitionToUser(SqlConnection databaseConnectionb, SqlCommand selectQuerryRecordsToBeadded);
        void RemovePermitionFromUser(SqlConnection databaseConnection, SqlCommand selectQuerryRecordsToBeRemoved);
        void AddAclColumnToTable(SqlConnection databaseConnection, string tableName);
    }
    
}
