using ACLDatabase.Model;

namespace ACLDatabase.Company.Auth
{
    //Interface IAuthentication which requires method authenticate
    //Expect to make authentication by Normal or AOP
    //From here we can add Factory for NormalAuth or AOPAuth
    public interface IAuthentication<T> where T : ModelContext
    {
        void Authenticate(IUser userName, T context);
    }
}