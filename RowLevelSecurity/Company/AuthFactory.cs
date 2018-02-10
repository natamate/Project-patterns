using ACLDatabase.Company.Auth;

namespace ACLDatabase.Company
{
    //Simple factory for Authentication methods
    public class AuthFactory
    {
        public Authentication GetAuthentication(string type)
        {
            if (type == null)
                return null;
            else if (type == "1")
                return new NormalAuthentication();
            else
                return new AspectAuthentication();
        }
    }
}
