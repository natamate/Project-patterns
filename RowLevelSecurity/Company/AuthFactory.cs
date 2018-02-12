using ACLDatabase.Company.Auth;
using ACLDatabase.Model;

namespace ACLDatabase.Company
{
    //Simple factory for IAuthentication methods
    public class AuthFactory<T> where T : ModelContext
    {
        public IAuthentication<T> GetAuthentication(string type)
        {
            switch (type)
            {
                case null:
                    return null;
                case "1":
                    return new NormalAuthentication<T>();
                default:
                    return new AspectAuthentication<T>();
            }
        }
    }
}
