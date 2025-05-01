using EmergencyAlert.Models;
using Microsoft.EntityFrameworkCore;

namespace EmergencyAlert.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)    {   }

    public DbSet <EmergencyEvent> Events { get; set; }
    public DbSet<EmergencyNotification> Notifications { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet <ResourceAssignment> ResourceAssignments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserNotification> UserNotifications { get; set; }
    public DbSet<Volunteer> Volunteers { get; set; }
    public DbSet<VolunteerAssignment> VolunteerAssignments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmergencyAlerts;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
     }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);
    }

}
