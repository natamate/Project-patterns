using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLForDatabase
{
    public interface IDBRole
    {
        /// <summary>
        ///  RoleID value must be power of 2 number e.g 1,2,4,8,16 etc.
        /// </summary>
        int RoleID { get; }
        string RoleName { get; }
        IList<IDBRole> ChildrenRoles { get; }
    }
}
