using System;
using ACLDatabase.Aspect;
using ACLDatabase.Company.DB;

namespace ACLDatabase.Company.Auth
{
    //Aspect Authentication
    public class AspectAuthentication : Authentication
    {
        [Authorize]
        public void Authenticate(string userName, CompanyContext context)
        {
            Console.WriteLine("Login as " + userName);
        }
    }
}