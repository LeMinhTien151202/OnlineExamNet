using Domain.Entities;
using ExamOnline.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Data
{
    public class ExamOnlineContext : IdentityDbContext<ApplicationUser>
    {
        public ExamOnlineContext(DbContextOptions<ExamOnlineContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Bắt buộc phải gọi phương thức cơ sở (base method)
            base.OnModelCreating(builder);
            // Các cấu hình mô hình bổ sung của bạn
            builder.Entity<Result>()
            .HasOne(r => r.User)
            .WithMany() // hoặc .WithMany(u => u.Results) nếu bạn muốn add collection trong User
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is IAuditable && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((IAuditable)entityEntry.Entity).UpdatedUp = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((IAuditable)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
