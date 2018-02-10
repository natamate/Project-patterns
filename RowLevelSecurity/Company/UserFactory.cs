namespace ACLDatabase.Company
{
    public class UserFactory
    {
        public string GetUser(string param)
        {
            switch (param)
            {
                case "1":
                    return "Boss_login";
                case "2":
                    return "Accountant_login";
                case "3":
                    return "Programist_login";
                case "4":
                    return "Intern_login";
                case "5":
                    return "Test_login";
            }
            return null;
        }
    }
}