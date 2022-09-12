using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ticketano.DAL.Models;

namespace Ticketano.DAL;

public class ApplicationDbContext: IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserRole,
    IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    public DbSet<User> AspNetUsers { get; set; }
    public DbSet<Role> AspNetRoles { get; set; }
    public DbSet<UserRole> AspNetUserRoles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EmailTemplates> EventEmailTemplates { get; set; }
    public DbSet<EventCategory> EventCategories { get; set; }
    public DbSet<EventFile> EventFiles { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Addon> Addons { get; set; }
    public DbSet<PackageAddon> PackageAddons { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<PlaceType> Types { get; set; }
    public DbSet<ShowProgram> ShowPrograms { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EventCategory>()
            .HasKey(c => new { c.CategoryId, c.EventId });
        
        modelBuilder.Entity<Event>()
            .HasIndex(x => x.Key)
            .IsUnique();
        
        modelBuilder.Entity<User>()
            .Property(x => x.LastActiveAt)
            .HasDefaultValueSql("(now() at time zone 'utc')");
        
        modelBuilder.Entity<Event>()
            .Property(x => x.DateFrom)
            .HasDefaultValueSql("(now() at time zone 'utc' + interval '1 month' * 3)");
        
        modelBuilder.Entity<Event>()
            .Property(x => x.DateTo)
            .HasDefaultValueSql("(now() at time zone 'utc' + interval '1 month' * 6)");
        
        modelBuilder.Entity<Event>()
            .Property(x => x.CreatedAt)
            .HasDefaultValueSql("(now() at time zone 'utc')");
        
        modelBuilder.Entity<Event>()
            .Property(x => x.UpdatedAt)
            .HasDefaultValueSql("(now() at time zone 'utc')");
        
        modelBuilder.Entity<UserRole>().HasKey(p => new { p.UserId, p.RoleId });
    }
}