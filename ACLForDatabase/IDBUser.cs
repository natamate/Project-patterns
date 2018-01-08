namespace ACLForDatabase
{   
    public interface IDBUser
    {
        int UserId { get;}
        string UserName { get; }
        IDBRole UserRole { get; }
        bool IsAdmin { get; }
    }
}
