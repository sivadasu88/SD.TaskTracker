
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SD.TaskTracker.Data.Model;
using SD.TaskTracker.Data.Tenant;

namespace SD.TaskTracker.Data.DataContext
{
    public abstract class TaskTrackerContext : DbContext
    {
        private readonly ITenantConnectionStringProvider _connectionStringProvider;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;



        public virtual DbSet<Feature> Features { get; set; }

        protected TaskTrackerContext(ITenantConnectionStringProvider connectionStringProvider, ILoggerFactory loggerFactory)
        {
            _connectionStringProvider = connectionStringProvider;
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.CreateLogger(nameof(TaskTrackerContext));
        }

        protected TaskTrackerContext(ITenantConnectionStringProvider connectionStringProvider, ILoggerFactory loggerFactory, DbContextOptions<TaskTrackerContext> options) : base(options)
        {
            _connectionStringProvider = connectionStringProvider;
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.CreateLogger(nameof(TaskTrackerContext));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _connectionStringProvider.GetConnectionString(DataStorePurpose.ReadOnly).GetAwaiter().GetResult();
                optionsBuilder.UseSqlServer(connectionString);

                optionsBuilder.UseLoggerFactory(_loggerFactory);
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Feature>().HasKey(c => new { c.FeatureOwnerID });

        }
    }
}
