using AttendanceSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AttendanceSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
        public DbSet<AdminViewLog> AdminViewLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure primary key explicitly just in case
            modelBuilder.Entity<AdminViewLog>()
                .HasKey(avl => avl.ViewLogId);

            modelBuilder.Entity<AdminViewLog>()
                .HasOne(avl => avl.Visitors)
                .WithMany()
                .HasForeignKey(avl => avl.VisitorId);
        }
    }
}