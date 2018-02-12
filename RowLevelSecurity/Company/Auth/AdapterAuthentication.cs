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
