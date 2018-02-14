using ACLDatabase.Company;

namespace ACLDatabase.UI
{
    public interface IView
    {
        void DrawGreetings();
        void ClearView();
        void DrawTable();
        string GetTypeOfConnection();
        IUser GetUser();
        void SetDrawingStrategy(IDrawingStrategy strategy);
        void SetSynContextStrategy(ISyncContextStrategy strategy);
    }
}
