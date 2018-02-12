namespace ACLDatabase.Company
{
    public class UserFactory
    {
        public IUser GetUser(string param)
        {
            switch (param)
            {
                case "1":
                    return new CompanyUser("Boss_login");
                case "2":
                    return new CompanyUser("Accountant_login");
                case "3":
                    return new CompanyUser("Programist_login");
                case "4":
                    return new CompanyUser("Intern_login");
                case "5":
                    return new CompanyUser("Test_login");
                default:
                    return null;
            }
            
        }
    }
}