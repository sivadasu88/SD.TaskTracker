using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SD.TaskTracker.Data.Tenant;

namespace SD.TaskTracker.Data.DataContext
{
    public class TaskTrackerReadContext : TaskTrackerContext
    {
        public TaskTrackerReadContext(ITenantConnectionStringProvider connectionStringProvider, ILoggerFactory loggerFactory, DbContextOptions<TaskTrackerContext> options) : base(connectionStringProvider, loggerFactory, options)
        {
        }

    }
}
