using ACLDatabase.Company.Auth;
using ACLDatabase.Model;

namespace ACLDatabase.Company
{
    //Simple factory for Authentication methods
    public class AuthFactory<T> where T : ModelContext
    {
        public Authentication<T> GetAuthentication(string type)
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
