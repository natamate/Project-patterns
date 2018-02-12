using System;
using ACLDatabase.Aspect;
using ACLDatabase.Company.DB;
using ACLDatabase.Model;

namespace ACLDatabase.Company.Auth
{
    //Aspect Authentication
    public class AspectAuthentication<T> : Authentication<T> where T : ModelContext
    {
        [Authorize]
        public void Authenticate(string userName, T context)
        {
            Console.WriteLine("Login as " + userName);
        }
    }
}