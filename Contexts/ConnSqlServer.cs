using apiUsers.Models;
using Microsoft.EntityFrameworkCore;

namespace apiUsers.Contexts;

public class ConnSqlServer(DbContextOptions<ConnSqlServer> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Position> Positions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(u => u.UserId);
        
        modelBuilder.Entity<Profile>()
            .HasKey(u => u.ProfileId);
        
        modelBuilder.Entity<Position>()
            .HasKey(u => u.PositionId);
        
        // Relación entre User y Profile
        modelBuilder.Entity<User>()
            .HasOne(u => u.Profile)         
            .WithMany(p => p.Users)          
            .HasForeignKey(u => u.ProfileId)
            .IsRequired();                 

        // Relación entre User y Position
        modelBuilder.Entity<User>()
            .HasOne(u => u.Position)  
            .WithMany(p => p.Users)         
            .HasForeignKey(u => u.PositionId)
            .IsRequired();  
    }
}