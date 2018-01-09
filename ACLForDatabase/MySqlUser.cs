using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLForDatabase
{
    public class MySqlUser : IDBUser
    {
        private MySqlUser(int userId, string userName, IDBRole userRole, bool isAdmin)
        {
            UserId = userId;
            UserName = userName;
            UserRole = userRole;
            IsAdmin = isAdmin;
        }

        public int UserId { get; }
        public string UserName { get; }
        public IDBRole UserRole { get; }
        public bool IsAdmin { get; }
    }
}
