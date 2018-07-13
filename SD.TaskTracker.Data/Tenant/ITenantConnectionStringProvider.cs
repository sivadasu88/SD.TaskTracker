using System.Threading.Tasks;

namespace SD.TaskTracker.Data.Tenant
{
    public interface ITenantConnectionStringProvider
    {
        Task<string> GetConnectionString(DataStorePurpose purpose);
    }
}
