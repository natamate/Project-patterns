using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACLDatabase.Company
{
    public class CompanyUser : IUser
    {
        public string Username { get; }

        public CompanyUser(string username)
        {
            Username = username;
        }
    }
}
