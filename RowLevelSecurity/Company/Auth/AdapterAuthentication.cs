using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACLDatabase.Model;

namespace ACLDatabase.Company.Auth
{
    public class AdapterAuthentication<T>: OldAuthentication<T>, IAuthentication<T> where T: ModelContext
    {
        public void Authenticate(IUser userName, T context)
        {
            MakeAuthentication(userName.Username, context);
        }
    }
}
