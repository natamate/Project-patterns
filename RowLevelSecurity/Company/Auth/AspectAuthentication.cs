using System;
using ACLDatabase.Aspect;
using ACLDatabase.Model;

namespace ACLDatabase.Company.Auth
{
    //Aspect IAuthentication
    public class AspectAuthentication<T> : IAuthentication<T> where T : ModelContext
    {
        [Authorize]
        public void Authenticate(IUser userName, T context)
        {
            Console.WriteLine("Login as " + userName.Username);
        }
    }
}