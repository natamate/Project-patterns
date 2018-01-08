using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLForDatabase
{
    public enum DbPrivilegeType
    {
        Delete = 1,
        Update = 2,
        Read = 4,
        Creat = 8
    }
}
