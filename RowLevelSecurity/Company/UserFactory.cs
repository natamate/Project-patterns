namespace ACLDatabase.Company
{
    public class UserFactory
    {
        public IUser GetUser(string param)
        {
            switch (param)
            {
                case "1":
                    return new CompanyUser("Trinh");
                case "2":
                    return new CompanyUser("Materek");
                case "3":
                    return new CompanyUser("Jakubowski");
                case "4":
                    return new CompanyUser("Lisiecki");
                case "5":
                    return new CompanyUser("Kowalski");
                default:
                    return new CompanyUser("Guset");
            }
            
        }
    }
}