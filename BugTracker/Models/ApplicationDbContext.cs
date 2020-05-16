using Microsoft.EntityFrameworkCore;

namespace BugTracker.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<UserViewedWorkItem> ViewedUserWorkItems { get; set; }
        public DbSet<UserWorkItem> TrackedUserWorkitems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserViewedWorkItem>(i => i.HasKey(x => new { x.UserId, x.WorkItemId }));
            modelBuilder.Entity<UserWorkItem>(i => i.HasKey(x => new { x.UserId, x.WorkItemId }));
            modelBuilder
                .Entity<WorkItem>()
                .HasOne(x => x.Project)
                .WithMany(x => x.WorkItems)
                .HasForeignKey(x => x.ProjectId);
        }
    }
}
