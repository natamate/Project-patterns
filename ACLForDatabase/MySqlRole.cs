using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLForDatabase
{
    class MySqlRole : IDBRole
    {
        public int RoleID { get; }
        public string RoleName { get; }
        public IList<IDBRole> ChildrenRoles { get; internal set; }

        public MySqlRole(int roleId, string roleName, IList<IDBRole> childrenRoles)
        {
            RoleID = roleId;
            RoleName = roleName;
            ChildrenRoles = childrenRoles;
        }
    }
}
