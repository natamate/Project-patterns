using System;
using ACLDatabase.Company.DB;
using ACLDatabase.Model;

namespace ACLDatabase.Company.Auth
{
    //Nomarl authentication
    public class NormalAuthentication<T> : IAuthentication<T> where T : ModelContext
    {
        public void Authenticate(IUser userName, T context)
        {
            IAuthentication<T> MyAdapter = new AdapterAuthentication<T>();
            MyAdapter.Authenticate(userName, context);
        }
    }
}