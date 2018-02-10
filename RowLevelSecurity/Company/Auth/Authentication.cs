using ACLDatabase.Company.DB;

namespace ACLDatabase.Company.Auth
{
    //Interface Authentication which requires method authenticate
    //Expect to make authentication by Normal or AOP
    //From here we can add Factory for NormalAuth or AOPAuth
    public interface Authentication
    {
        void Authenticate(string userName, CompanyContext context);
    }
}