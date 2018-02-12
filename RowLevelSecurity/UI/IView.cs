namespace ACLDatabase.UI
{
    public interface IView
    {
        void DrawGreetings();
        void ClearView();
        void DrawTable();
        string GetTypeOfConnection();
        Company.IUser GetUser();
        void SetDrawingStrategy(IDrawingStrategy stratefy);
    }
}
