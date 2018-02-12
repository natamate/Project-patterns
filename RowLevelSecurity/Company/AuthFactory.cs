using ACLDatabase.Company.Auth;
using ACLDatabase.Model;

namespace ACLDatabase.Company
{
    //Simple factory for IAuthentication methods
    public class AuthFactory<T> where T : ModelContext
    {
        public IAuthentication<T> GetAuthentication(string type)
        {
            if (type == null)
                return null;
            else if (type == "1")
                return new NormalAuthentication<T>();
            else
                return new AspectAuthentication<T>();
        }
    }
}
