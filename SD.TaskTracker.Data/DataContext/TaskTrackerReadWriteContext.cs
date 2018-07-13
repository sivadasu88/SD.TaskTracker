using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SD.TaskTracker.Data.DataContext;
using SD.TaskTracker.Data.Tenant;

namespace Ipreo.NS.Permissions.Data.Repository.DataContext
{
    public class TaskTrackerReadWriteContext : TaskTrackerContext
    {
        public TaskTrackerReadWriteContext(ITenantConnectionStringProvider connectionStringProvider, ILoggerFactory loggerFactory, DbContextOptions<TaskTrackerContext> options) : base(connectionStringProvider, loggerFactory, options)
        {
        }
    }
}
