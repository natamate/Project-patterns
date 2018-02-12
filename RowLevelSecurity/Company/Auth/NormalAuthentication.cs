using System;
using ACLDatabase.Company.DB;
using ACLDatabase.Model;

namespace ACLDatabase.Company.Auth
{
    //Nomarl authentication
    public class NormalAuthentication<T> : Authentication<T> where T : ModelContext
    {
        public void Authenticate(string userName, T context)
        {
            Authentication<T> MyAdapter = new AdapterAuthentication<T>();
            MyAdapter.Authenticate(userName, context);
        }
    }
}