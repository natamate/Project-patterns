namespace ACLDatabase.Company
{
    public class CompanyUser : IUser
    {
        public string Username { get; }

        public CompanyUser(string username)
        {
            Username = username;
        }
    }
}
