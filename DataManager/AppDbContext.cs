using Authentication.Models;
using Coverage.Models;
using HealthcareProvider.Models;
using Language.Models;
using Microsoft.EntityFrameworkCore;
using User.Models;

namespace DataManager;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // User
    public DbSet<User.Models.User> Users { get; set; }
    public DbSet<Email> Emails { get; set; }
    public DbSet<Telephone> Telephones { get; set; }

    // Authentication
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Right> Rights { get; set; }

    // Coverage
    public DbSet<Client> Clients { get; set; }
    public DbSet<Coverage.Models.Coverage> Coverages { get; set; }
    public DbSet<ClientLog> ClientLogs { get; set; }
    public DbSet<Caretaker> Caretakers { get; set; }

    // HealthcareProvider
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<City> Cities { get; set; }

    // HealthCard
    public DbSet<HealthCard.Models.HealthCard> HealthCards { get; set; }

    // Language
    public DbSet<Language.Models.Language> Languages { get; set; }
    public DbSet<Text> Texts { get; set; }
    public DbSet<Settings> Settings { get; set; }

    // SystemLog
    public DbSet<SystemLog.Models.SystemLog> SystemLogs { get; set; }

    // Notification
    public DbSet<Notification.Models.Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Admin M---N Role
        modelBuilder.Entity<Admin>()
            .HasMany<Role>()
            .WithMany()
            .UsingEntity(j => j.ToTable("AdminRoles"));

        // Role M---N Right
        modelBuilder.Entity<Role>()
            .HasMany<Right>()
            .WithMany()
            .UsingEntity(j => j.ToTable("RoleRights"));

        // User 1---M Email
        modelBuilder.Entity<Email>()
            .HasOne<User.Models.User>()
            .WithMany()
            .HasForeignKey(e => e.UserId);

        // Telephone N---M User
        modelBuilder.Entity<Telephone>()
            .HasMany<User.Models.User>()
            .WithMany()
            .UsingEntity(j => j.ToTable("UserTelephones"));

        // Client M---N Coverage
        modelBuilder.Entity<Client>()
            .HasMany<Coverage.Models.Coverage>()
            .WithMany()
            .UsingEntity(j => j.ToTable("ClientCoverages"));

        // Client M---N Caretaker
        modelBuilder.Entity<Client>()
            .HasMany<Caretaker>()
            .WithMany()
            .UsingEntity(j => j.ToTable("ClientCaretakers"));

        // Client 1---M ClientLog
        modelBuilder.Entity<ClientLog>()
            .HasOne<Client>()
            .WithMany()
            .HasForeignKey(cl => cl.ClientId);

        // Text M---1 Language
        modelBuilder.Entity<Text>()
            .HasOne<Language.Models.Language>()
            .WithMany()
            .HasForeignKey(t => t.LanguageId);

        // Language 1---M Settings
        modelBuilder.Entity<Settings>()
            .HasOne<Language.Models.Language>()
            .WithMany()
            .HasForeignKey(s => s.LanguageId);
    }
}
