using System;
using ACLDatabase.Company.DB;

namespace ACLDatabase.Company.Auth
{
    //Nomarl authentication
    public class NormalAuthentication : Authentication
    {
        public void Authenticate(string userName, CompanyContext context)
        {
            context.Authorize(userName);
            Console.WriteLine("Login as " + userName);
        }
    }
}