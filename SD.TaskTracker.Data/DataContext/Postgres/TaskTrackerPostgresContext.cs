
using Microsoft.EntityFrameworkCore;
using SD.TaskTracker.Data.Model;

namespace SD.TaskTracker.Data.DataContext
{
    public class TaskTrackerPostgresContext : DbContext
    {

        public TaskTrackerPostgresContext(DbContextOptions<TaskTrackerPostgresContext> options) : base(options)
        {
        }

        public virtual DbSet<FeatureRecord> Features { get; set; }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            return base.SaveChanges();
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FeatureRecord>().ToTable("Feature");
            modelBuilder.Entity<FeatureRecord>().HasKey(c => new { c.FeatureName });

        }
    }
}
