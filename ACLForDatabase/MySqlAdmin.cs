using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLForDatabase
{
    // TO COMPLETE
    class MySqlAdmin : IDBAdmin, IDBUser
    {
        private static MySqlAdmin _instance;

        public int UserId { get; }
        public string UserName { get; }
        public IDBRole UserRole { get; }
        public bool IsAdmin { get; }
        public static MySqlAdmin Instance => _instance ?? new MySqlAdmin();
        
        private MySqlAdmin()
        {
            UserId = 0;
            UserRole = new MySqlRole(0, "Administrators", null);
            UserName = "admin";
            IsAdmin = true;
        }

       

        public void AddPrivilegesToRole(SqlConnection connection, DBPrivilegeType privileges)
        {
            throw new NotImplementedException();
        }

        public void RemovePrivilegeFromRole(SqlConnection connection, IDBRole role, SqlCommand sqlCommand)
        {
            throw new NotImplementedException();
        }

        public void AssignRoleToUser(IDBUser user, IDBRole role)
        {
            throw new NotImplementedException();
        }

        public void RenameUser(IDBUser user)
        {
            throw new NotImplementedException();
        }

        public void AddDatabaseUser(IDBUser user)
        {
            throw new NotImplementedException();
        }

        
    }
}
