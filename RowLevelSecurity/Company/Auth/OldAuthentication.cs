using System;
using ACLDatabase.Model;

namespace ACLDatabase.Company.Auth
{
    //Nomarl authentication
    public class OldAuthentication<T> where T : ModelContext
    {
        public void MakeAuthentication(string userName, T context)
        {
            context.Authorize(userName);
            Console.WriteLine("Login as " + userName);
        }
    }
}