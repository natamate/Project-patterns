using ACLDatabase.Company.DB;

namespace ACLDatabase.UI
{
    public interface ISyncContextStrategy
    {
        void SyncContextWithDb(CompanyContext context);
    }
}
