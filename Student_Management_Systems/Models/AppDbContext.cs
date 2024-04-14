using Microsoft.EntityFrameworkCore;
using Student_Management_Systems.Models;

public class AppDbContext : DbContext
{
    public DbSet<Users> Users { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Specify the path to your database file
        optionsBuilder.UseSqlite("Data Source=studentmanagement.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>()
       .HasMany(u => u.Grades) // A user has many grades
       .WithOne(g => g.User)   // Each grade belongs to one user
       .HasForeignKey(g => g.UserId); // Foreign key in the Grade table pointing to the User table


        modelBuilder.Entity<Notification>()
            .HasOne(n => n.Sender)
            .WithMany()
            .HasForeignKey(n => n.SenderUserId);
    }
}