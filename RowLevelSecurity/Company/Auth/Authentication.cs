using ACLDatabase.Company.DB;
using ACLDatabase.Model;

namespace ACLDatabase.Company.Auth
{
    //Interface Authentication which requires method authenticate
    //Expect to make authentication by Normal or AOP
    //From here we can add Factory for NormalAuth or AOPAuth
    public interface Authentication<T> where T : ModelContext
    {
        void Authenticate(string userName, T context);
    }
}