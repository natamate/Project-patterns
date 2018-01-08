using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLForDatabase
{
    public enum DBPrivilegeType
    {
        Select = 1,
        SelectAndUpdate = 2,
        SelectUpdateDelete = 4
    }
}
