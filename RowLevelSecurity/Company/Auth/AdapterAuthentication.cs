using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACLDatabase.Model;

namespace ACLDatabase.Company.Auth
{
    public class AdapterAuthentication<T>: OldAuthentication<T>, Authentication<T> where T: ModelContext
    {
        public void Authenticate(string userName, T context)
        {
            MakeAuthentication(userName, context);
        }
    }
}
