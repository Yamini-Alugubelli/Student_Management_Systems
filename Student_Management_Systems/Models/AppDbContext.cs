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
       .HasKey(u => u.UserId); // Configure the primary key
                               // Other configurations...




        modelBuilder.Entity<Users>()
       .HasMany(u => u.Grades) // A user has many grades
       .WithOne(g => g.User)   // Each grade belongs to one user
       .HasForeignKey(g => g.UserId); // Foreign key in the Grade table pointing to the User table
        



        modelBuilder.Entity<Grade>()
                .HasOne(g => g.User) // Ensure navigation property is correctly configured
                .WithMany(u => u.Grades)
                .HasForeignKey(g => g.UserId);


        modelBuilder.Entity<Notification>()
        .HasOne(n => n.Sender) // Configure the relationship properly if you have not already
        .WithMany(u => u.Notifications) // Assuming User has a collection of Notifications
        .HasForeignKey(n => n.UserId); // UserId is the foreign key in Notification table

    }
}