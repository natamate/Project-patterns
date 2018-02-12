using ACLDatabase.Model;

namespace ACLDatabase.Company.Auth
{
    //Nomarl authentication
    public class NormalAuthentication<T> : IAuthentication<T> where T : ModelContext
    {
        public void Authenticate(IUser userName, T context)
        {
            IAuthentication<T> myAdapter = new AdapterAuthentication<T>();
            myAdapter.Authenticate(userName, context);
        }
    }
}