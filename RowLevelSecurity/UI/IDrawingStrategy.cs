using ACLDatabase.Company.DB;

namespace ACLDatabase.UI
{
    public interface IDrawingStrategy
    {
        void DrawSpecificTable(CompanyContext context);
        void SyncContextWithDb(CompanyContext context);
    }
}
